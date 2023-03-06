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

namespace LoadPullSystemControl.Instruments
{
    /// <summary>
    /// Class <c>MauryTunerDriver</c> handles the tuner controls. Only supports a single input and output tuner
    /// </summary>
    internal class MauryTunerDriver
    {
        private short controllerNumber {get;}
        private short serial { get;}
        private short controllerPort { get;}
        private short gpibAddress { get;}
        private short tunerNumber { get;}
        private short ctrlSerial { get;}

        string tunerModel;
        private string ctrlModel;

        string outTunerCharFilePath;
        string ctrlDriverPath;

        string tunerExeFilePath;

        string inTunerArguments = "";
        string outTunerArguments = "";

        // Checks if tuner controller was already initialised
        private static bool ctrlInitialised = false; 
        public MauryTunerDriver(short tunerNumber, short controllerNumber, short serial, short ctrlSerial, 
                            short ctrlPort, short gpibAddress, string tunerExeFilePath = "CppDllTest.exe") 
        {
            // Leaving all the port and controller initialisation in case someone figures out 
            // how to use dlls in c# properly without errors.
            this.tunerNumber = tunerNumber;
            this.controllerNumber = controllerNumber;
            this.serial = serial;
            this.controllerPort = ctrlPort;
            this.gpibAddress = gpibAddress;
            this.ctrlSerial = ctrlSerial;
            if (!File.Exists(tunerExeFilePath))

            {
                throw new Exception("Executable file could not be found");
            }
            this.tunerExeFilePath= tunerExeFilePath;

        }

        /// <summary>
        /// Sets the executable arguments for the input and output tuner
        /// </summary>
        /// <param name="ctrlDriverPath">Path to the controller driver</param>
        /// <param name="outTunerCharFilePath">Path to the output tuner characterization file</param>
        /// <param name="inTunerCharFilePath">Path to the input tuner characterization file</param>
        public void InitTuner(string ctrlDriverPath, string outTunerCharFilePath, string inTunerCharFilePath)
        {

            this.ctrlDriverPath = ctrlDriverPath;
            this.outTunerCharFilePath= outTunerCharFilePath;
            string baseArguments = String.Format("init \"{0}\" {1} ", ctrlDriverPath, gpibAddress);

            // Tuner number is always 0 because we are only moving only a single tuner at the time
            string secondArgs;
            if(inTunerCharFilePath.Length > 0 )
            {
                secondArgs = String.Format("\"{0}\" {1} {2}", inTunerCharFilePath, 0, 1);
                this.inTunerArguments = baseArguments + secondArgs;
            }
            secondArgs = String.Format("\"{0}\" {1} {2}", outTunerCharFilePath, 0, 0);
            this.outTunerArguments= baseArguments + secondArgs;
        }

        public void DeinitTuner()
        {
            throw new NotImplementedException();

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
            Complex gamma = (impedance - Z0)/(impedance + Z0);
            if(sParams != null)
            {
                gamma = (gamma - sParams[0]) / (sParams[3]*(gamma-sParams[3]) + sParams[1]*sParams[2]);
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
            string arguments;
            if(inputTuner)
            {
                arguments = inTunerArguments;
            }
            else
            {
                arguments = outTunerArguments;
            }
            string finalArguments = String.Format("{0} {1} {2} {3} {4}", arguments, reflection.Real, reflection.Imaginary, 
                                                                        freq.ToString(CultureInfo.InvariantCulture.NumberFormat), 0);
            RunProcess(tunerExeFilePath, finalArguments);
        }

        /// <summary>
        /// Utility method that runs the executable for controlling the tuner
        /// </summary>
        /// <param name="path">Path to the executable</param>
        /// <param name="arguments">Arguments whith which the executable is run</param>
        /// <returns></returns>
        private string RunProcess(string path, string arguments)
        { 
                // Get the standard output from the process
            string output = "";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = path;

                p.StartInfo.Arguments = arguments;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();

                while (!p.StandardOutput.EndOfStream)
                {
                    output += p.StandardOutput.ReadLine() + Environment.NewLine;
                }
            }
            return output;

        }
    }
}
