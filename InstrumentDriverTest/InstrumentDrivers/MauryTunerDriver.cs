using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace InstrumentDriverTest.Instruments
{
    /// <summary>
    /// Class <c>MauryTunerDriver</c> handles the tuner controls. Only supports a single input and output tuner
    /// </summary>
    public class MauryTunerDriver
    {
        private short controllerNumber { get; }
        private short serial { get; }
        private short controllerPort { get; }
        private short gpibAddress { get; }
        private short tunerNumber { get; }
        private short ctrlSerial { get; }

        string tunerModel;
        private string ctrlModel;

        string inTunerCharFilePath;
        string outTunerCharFilePath;
        string ctrlDriverPath;

        string tunerExeFilePath;

        string inTunerArguments = "";
        string outTunerArguments = "";

        // Checks if tuner controller was already initialised
        private static bool ctrlInitialised = false;
        public MauryTunerDriver(short gpibAddress, string driverPath,string inTunerCharFilePath, string outTunerCharFilePath)
        {

            if (!File.Exists(driverPath))
            {
                throw new Exception("Driver file not found");
            }
            if (!File.Exists(inTunerCharFilePath))
            {
                throw new Exception("Input tuner characerization file not found");
            }
            if (!File.Exists(outTunerCharFilePath))
            {
                throw new Exception("Input tuner characerization file not found");
            }

            this.gpibAddress = gpibAddress;
            this.tunerModel = "MT982EU30\0";
            this.ctrlModel = "MT986B02\0";
            this.ctrlDriverPath = driverPath + "\0";
            this.inTunerCharFilePath = inTunerCharFilePath + "\0";
            this.outTunerCharFilePath = outTunerCharFilePath + "\0";


            // Add the input tuner and initialize it
            int err_code = 0;
            char[] error_string = new char[1000];

            err_code = MauryTunerFunctions.add_tuner_ex(0, this.ctrlDriverPath.ToCharArray(), tunerModel.ToCharArray(), 1331, gpibAddress, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.read_tuner_data_file(0, this.inTunerCharFilePath.ToCharArray(), tunerModel.ToCharArray(), error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.add_controller_ex(0, ctrlModel.ToCharArray(), 0, 1, 0, gpibAddress, 0, (short)2048, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.init_tuners(error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            // Remove the first tuner and add the output tuner and initialize it

            err_code = MauryTunerFunctions.delete_tuner_ex(0, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            err_code = MauryTunerFunctions.add_tuner_ex(0, this.ctrlDriverPath.ToCharArray(), tunerModel.ToCharArray(), 1333, gpibAddress, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.read_tuner_data_file(0, this.outTunerCharFilePath.ToCharArray(), tunerModel.ToCharArray(), error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.add_controller_ex(0, ctrlModel.ToCharArray(), 0, 2, 0, gpibAddress, 0, (short)2048, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.init_tuners(error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            // Re-add the input tuner, it doesn't need to be reinitialised again
            err_code = MauryTunerFunctions.add_tuner_ex(1, this.ctrlDriverPath.ToCharArray(), tunerModel.ToCharArray(), 1331, gpibAddress, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.read_tuner_data_file(1, this.inTunerCharFilePath.ToCharArray(), tunerModel.ToCharArray(), error_string);
            if (err_code != 0) throw new Exception(new string(error_string));
            err_code = MauryTunerFunctions.add_controller_ex(1, ctrlModel.ToCharArray(), 0, 1, 0, gpibAddress, 0, (short)2048, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            // Move tuners to 0 reflection or 50 ohms

            try
            {
                MoveTunerToSmithPosition(true, new Complex(0, 0), 2.4);
                MoveTunerToSmithPosition(false, new Complex(0, 0), 2.4);
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        /// <summary>
        /// Moves the tuner to the specified impedance
        /// </summary>
        /// <param name="inputTuner">true if the tuner to move is input tuner and false otherwise</param>
        /// <param name="impedance">Impedance the tuner is set to</param>
        /// <param name="freq">Frequency for which the tuner is moving</param>
        /// <param name="sParams">S-parameters for de-embedding</param>
        public void MoveTunerToImpedance(bool inputTuner, Complex impedance, double freq, List<Complex> sParams = null)
        {
            Complex Z0 = new Complex(50, 0);
            Complex gamma = (impedance - Z0) / (impedance + Z0);
            if (sParams != null)
            {
                gamma = (gamma - sParams[0]) / (sParams[3] * (gamma - sParams[3]) + sParams[1] * sParams[2]);
            }
            MoveTunerToSmithPosition(inputTuner, gamma, freq);
        }

        /// <summary>
        /// Moves the tuner to the specified reflection
        /// </summary>
        /// <param name="inputTuner">true if the tuner to move is input tuner and false otherwise</param>
        /// <param name="reflection">Refletction the tuner is set to</param>
        /// <param name="freq">Frequency for which the tuner is moving</param>
        public void MoveTunerToSmithPosition(bool inputTuner, Complex reflection, double freq)
        {
            // Tuner number is 0 for output tuner and 1 for input tuner
            short tunerNumber = (short)(inputTuner ? 1 : 0);

            char[] error_string = new char[1000];

            int carr, p1, p2;
            try
            {
                (carr, p1, p2) = GetTunerPositionForReflection(tunerNumber, reflection, freq);
            }
            catch (Exception e) 
            {
                throw e;
            }
            int err_code = MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, error_string); 
            if (err_code != 0) throw new Exception(new string(error_string));

        }

        public (int, int, int) GetTunerPositionForReflection(short tunerNumber, Complex reflection, double freq)
        {

            int carr = 0;
            int p1 = 0;
            int p2 = 0;
            double[] s11_x = new double[10];
            double[] s11_y = new double[10];
            double[] s21_x = new double[10];
            double[] s21_y = new double[10];
            double[] s12_x = new double[10];
            double[] s12_y = new double[10];
            double[] s22_x = new double[10];
            double[] s22_y = new double[10];
            char[] error_string = new char[1000];

            int err_code = MauryTunerFunctions.get_tuner_refl_data(tunerNumber,0, freq, 0, 0, reflection.Real, reflection.Imaginary, 
                                                                    ref carr, ref p1, ref p2, s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, s22_x, s22_y, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            return (carr, p1, p2);
        }

    }
}
