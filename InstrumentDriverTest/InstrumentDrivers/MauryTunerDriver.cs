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

            /* Why the \0:
             * 
             * The dll file being called is a C-language dll
             * C takes a character array (char[] in C#) as the input instead of a string
             * so you will see a cast to char array being done when calling the tuner functions
             * 
             * The problem is that C determines when the string is terminated by it ending with a '\0' character
             * This character is NOT used in C# strings as the language works differently.
             * To avoid errors, and allow the dll file to properly function, it is neccessary to add '\0' to each
             * string being passed to the dll functions.
             * 
             */
            this.tunerModel = "MT982EU30\0";
            this.ctrlModel = "MT986B02\0";
            this.ctrlDriverPath = driverPath + "\0";
            this.inTunerCharFilePath = inTunerCharFilePath + "\0";
            this.outTunerCharFilePath = outTunerCharFilePath + "\0";


            // Add the input tuner and initialize it
            int err_code;
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

            // Move tuners to 0 reflection or 50 ohms, this is not de-embedded so do it manually
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
            try
            {
                MoveTunerToSmithPosition(inputTuner, gamma, freq);
            }
            catch (Exception e) { throw e; }
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

        /// <summary>
        /// Get the position for the tuner motors for the wanted reflection at specified frequency
        /// </summary>
        /// <param name="tunerNumber"></param>
        /// <param name="reflection"></param>
        /// <param name="freq"></param>
        /// <returns>carriage, p1 and p2 positions for the tuner</returns>
        /// <exception cref="Exception">Throws Exception if an error occurs inside the tuner function</exception>
        private (int, int, int) GetTunerPositionForReflection(short tunerNumber, Complex reflection, double freq)
        {
            int carr = 0;
            int p1 = 0;
            int p2 = 0;
            // These have to be initialised for the function, if you need these s-parameters,
            // use the GetTunerSParams method
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
                                                                    ref carr, ref p1, ref p2, 
                                                                    s11_x, s11_y, s21_x, s21_y, 
                                                                    s12_x, s12_y, s22_x, s22_y, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            return (carr, p1, p2);
        }

        /// <summary>
        /// Returns the s parameters for the 3 harmonics for the tuner in the current position.
        /// </summary>
        /// <param name="inputTuner">true if getting s-parameters for the input tuner, false otherwise</param>
        /// <param name="freq">Frequency of operation</param>
        /// <returns>Dictionary where key is the s-parameter string (ex. "s11") and the value is the three s-parameters
        ///          one per harmonic</returns>
        /// <exception cref="Exception">Throws Exception if an error occurs inside the tuner function</exception>
        public Dictionary<string, List<Complex>> GetTunerSParams(bool inputTuner, double freq)
        {
            // Tuner number is 0 for output tuner and 1 for input tuner
            short tunerNumber = (short)(inputTuner ? 1 : 0);

            char[] error_string = new char[1000];
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

            // Get the current Tuner position
            int err_code = MauryTunerFunctions.get_tuner_position(tunerNumber, ref carr, ref p1, ref p2, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            // Get the s parameters for the current tuner position
            err_code = MauryTunerFunctions.get_tuner_position_spara(tunerNumber, freq, 0, ref carr, ref p1, ref p2,
                                                                        s11_x, s11_y, s21_x, s21_y,
                                                                         s12_x, s12_y, s22_x, s22_y, error_string);
            if (err_code != 0) throw new Exception(new string(error_string));

            // get_tuner_position_spara returns s parameters for 3 harmonics (supposedly)
            // We create a dictionary where each key is the s parameter name (ex. "s11")
            // and the value is a list of 3 s parameters for the harmonics
            Dictionary<string, List<Complex>> sParams = new Dictionary<string, List<Complex>>
            {
                { 
                    "s11", new List<Complex>
                    {
                        new Complex(s11_x[0], s11_y[0]),
                        new Complex(s11_x[1], s11_y[1]),
                        new Complex(s11_x[2], s11_y[2]),
                    }
                },
                {
                    "s12", new List<Complex>
                    {
                        new Complex(s12_x[0], s12_y[0]),
                        new Complex(s12_x[1], s12_y[1]),
                        new Complex(s12_x[2], s12_y[2]),
                    }
                },
                {
                    "s21", new List<Complex>
                    {
                        new Complex(s21_x[0], s21_y[0]),
                        new Complex(s21_x[1], s21_y[1]),
                        new Complex(s21_x[2], s21_y[2]),
                    }
                },
                {
                    "s22", new List<Complex>
                    {
                        new Complex(s22_x[0], s22_y[0]),
                        new Complex(s22_x[1], s22_y[1]),
                        new Complex(s22_x[2], s22_y[2]),
                    }
                }
            };

            return sParams;
        }
    }
}
