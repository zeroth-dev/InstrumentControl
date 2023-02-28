using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;

namespace InstrumentDriverTest.Instruments
{
    internal class MauryTunerDriver
    {
        private short controllerNumber {get;}
        private short serial { get;}
        private short controllerPort { get;}
        private short address { get;}
        private short tunerNumber { get;}
        // Model used is MT986B02 
        private char[] model = new char[]{'M', 'T', '9', '8', '6', 'B', '0', '2'};
        private short numOfMotors = 3;
        private long[] maxRange = { 21200, 5000, 5000};
        private double fmin = 0.8f;
        private double fmax = 8f;
        private double fcrossover = 2.8f;
        private Complex[] sParams = new Complex[4];
        public MauryTunerDriver(short tunerNumber, short controllerNumber, short serial, short ctlrPort, short address) 
        {
            this.tunerNumber = tunerNumber;
            this.controllerNumber = controllerNumber;
            this.serial = serial;
            this.controllerPort = ctlrPort;
            this.address = address;

            if (serial == 1331)
            {
                sParams[0] = new Complex(-0.03344842, 0.06450597);
                sParams[1] = new Complex(0.904200436, -0.187861404);
                sParams[2] = new Complex(0.912585899, -0.178581016);
                sParams[3] = new Complex(-0.030925365, +0.0829574763);
            }
            else if(serial == 1333)
            {
                sParams[0] = new Complex(0.08234115975993, -0.1949504542731);
                sParams[1] = new Complex(0.814841554901, 0.343276687698);
                sParams[2] = new Complex(0.8310923133441, 0.3430014439857);
                sParams[3] = new Complex(-0.1870113417405, 0.1143918230569);
            }
            else
            {
                throw new Exception("Unknown tuner serial number");
            }

        }

        public void initTuner(string driverPath)
        {

            char[] error =  new char[100];
            int errorCode = MauryTunerFunctions.add_controller(controllerNumber, driverPath.ToCharArray(), model, 0, address, 0, serial, out error);
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }
            errorCode = MauryTunerFunctions.add_tuner(0, model, serial, controllerNumber, controllerPort, out numOfMotors, 
                                                        out maxRange, out fmin, out fmax, out fcrossover, out error);

            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }
        }

        public void deinitTuner()
        {
            char[] error = new char[100];
            int errorCode = MauryTunerFunctions.delete_tuner_ex(tunerNumber, out error);
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }
            errorCode = MauryTunerFunctions.delete_controller_ex(controllerNumber, out error);  
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }

        }

        public void moveTunerToImpedance(string tunerDataFilePath, Complex impedance, double freq)
        {

            char[] error = new char[100];
            var err = MauryTunerFunctions.read_tuner_data_file(tunerNumber, tunerDataFilePath.ToCharArray(), model, out error);
            if(err != 0)
            {
                throw new Exception(new string(error));
            }
            Complex Z0= new Complex(50,0);
            Complex gamma = (impedance - Z0) / (impedance + Z0);

            Complex target = (gamma - sParams[0])/(sParams[4]*(gamma-sParams[4])+sParams[2]*sParams[1]);

            long carr;
            long p1;
            long p2;
            double[] dummy = new double[3];
            err = MauryTunerFunctions.get_tuner_refl_data(tunerNumber, 0, freq, 0, 0, target.Real, target.Imaginary, out carr, out p1, out p2,
                                                    out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out error);
            if (err != 0)
            {
                throw new Exception(new string(error));
            }
            err = MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, out error);
            if (err != 0)
            {
                throw new Exception(new string(error));
            }
        }

        public void moveTunerToSmithPosition(Complex position, double freq)
        {
            Complex target = (position - sParams[0]) / (sParams[4] * (position - sParams[4]) + sParams[2] * sParams[1]);

            char[] error = new char[100];
            long carr;
            long p1;
            long p2;
            double[] dummy = new double[3];
            MauryTunerFunctions.get_tuner_refl_data(tunerNumber, 0, freq, 0, 0, target.Real, target.Imaginary, out carr, out p1, out p2,
                                                    out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out dummy, out error);

            MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, out error);
        }
    }
}
