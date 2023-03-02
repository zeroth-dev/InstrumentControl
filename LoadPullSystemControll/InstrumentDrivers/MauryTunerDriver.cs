using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;
using System.Threading;
using System.Diagnostics;

namespace LoadPullSystemControl.Instruments
{
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

        string tunerCharFilePath;
        string ctrlDriverPath;

        string tunerExeFilePath;

        // Checks if tuner controller was already initialised
        private static bool ctrlInitialised = false; 
        public MauryTunerDriver(short tunerNumber, short controllerNumber, short serial, short ctrlSerial, 
                            short ctrlPort, short gpibAddress, string tunerExeFilePath = "CppDllTest.exe") 
        {
            this.tunerNumber = tunerNumber;
            this.controllerNumber = controllerNumber;
            this.serial = serial;
            this.controllerPort = ctrlPort;
            this.gpibAddress = gpibAddress;
            this.ctrlSerial = ctrlSerial;
            this.tunerExeFilePath= tunerExeFilePath;

        }

        public void InitTuner(string ctrlDriverPath, string tunerCharFilePath, int tunerNumber, 
                                bool inputTuner)
        {

            this.ctrlDriverPath = ctrlDriverPath;
            this.tunerCharFilePath= tunerCharFilePath;
            string arguments = "";
            if(!ctrlInitialised)
            {
                arguments = String.Format("init controller \"{0}\" {1}", ctrlDriverPath, gpibAddress);
                RunProcess(tunerExeFilePath, arguments);
                ctrlInitialised = true;
            }
            arguments = String.Format("init tuner \"{0}\" {1} {2}", tunerCharFilePath, tunerNumber, inputTuner);
            RunProcess(tunerExeFilePath, arguments);
        }

        public void DeinitTuner()
        {
        

        }

        public void MoveTunerToImpedance( int tunerNumber, Complex impedance, double freq, List<Complex> sParams = null)
        {
            Complex Z0 = new Complex(50, 0);
            Complex gamma = (impedance - Z0)/(impedance + Z0);
            if(sParams != null)
            {
                gamma = (gamma - sParams[0]) / (sParams[3]*(gamma-sParams[3]) + sParams[1]*sParams[2]);
            }
            MoveTunerToSmithPosition(tunerNumber, gamma, freq);
        }

        public void MoveTunerToSmithPosition(int tunerNumber, Complex reflection, double freq)
        {
            string arguments = String.Format("set {0} {1} {2} {3} {4}", tunerNumber, reflection.Real, reflection.Imaginary, freq, false);
            RunProcess(tunerCharFilePath, arguments);
        }

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
