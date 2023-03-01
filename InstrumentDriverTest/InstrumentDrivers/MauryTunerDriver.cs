using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;
using System.Threading;

namespace InstrumentDriverTest.Instruments
{
    internal class MauryTunerDriver
    {
        private short controllerNumber {get;}
        private short serial { get;}
        private short controllerPort { get;}
        private short address { get;}
        private short tunerNumber { get;}
        private short ctrlrSerial { get;}

        string tunerModel = "MT982EU30";
        // Model used is MT986B02 
        private char[] model = new char[]{'M', 'T', '9', '8', '6', 'B', '0', '2'};
        private short numOfMotors = 3;
        private int[] maxRange = new int[3]; //{ 21200, 5000, 5000};
        private double fmin = 0.8f;
        private double fmax = 8f;
        private double fcrossover = 2.8f;
        private Complex[] sParams = new Complex[4];
        public MauryTunerDriver(short tunerNumber, short controllerNumber, short serial, short ctrlrSerial, short ctlrPort, short address) 
        {
            this.tunerNumber = tunerNumber;
            this.controllerNumber = controllerNumber;
            this.serial = serial;
            this.controllerPort = ctlrPort;
            this.address = address;
            this.ctrlrSerial = ctrlrSerial;

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
            char[] error2 = new char[500];
            StringBuilder test = new StringBuilder();
            int errorCode = 0;
            // Add controller
            try
            {
                errorCode = MauryTunerFunctions.add_controller(controllerNumber, driverPath.ToCharArray(), model, 30, address, 0, ctrlrSerial, error);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(new string(error));
            }
            //Init tuners
            try
            {
                string test2 = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll\0";
                errorCode = MauryTunerFunctions.add_tuner_ex(0, test2.ToCharArray(), tunerModel.ToCharArray(), serial, address, error);

                //errorCode = MauryTunerFunctions.add_tuner(0, tunerModel.ToCharArray(), 1333, 0, 2, numOfMotors, maxRange,
                 //                                           fmin, fmax, fcrossover, error);
                if (errorCode != 0)
                {
                    throw new Exception(new string(error));
                }
                string tunTest = "C:/Users/korisnik/Documents/karakterizacija_fund_2400MHz_all.tun\0";
                var fileTest = tunTest.ToCharArray();
                errorCode = MauryTunerFunctions.read_tuner_data_file(0, fileTest, model, error2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (errorCode != 0)
            {
                Console.WriteLine(error2);
                throw new Exception(new string(error2));
            }

            // Add tuners
            try
            {
                }
            catch(Exception ex)
            {
                throw ex;
            }
            //errorCode = MauryTunerFunctions.init_tuners(error);

            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(new string(error));
            }

            long carr =110;
            long p1 = 5100;
            long p2 = 5100;
            double[] s11_x = new double[10];
            double[] s11_y = new double[10];
            double[] s21_x = new double[10];
            double[] s21_y = new double[10];
            double[] s12_x = new double[10];
            double[] s12_y = new double[10];
            double[] s22_x = new double[10];
            double[] s22_y = new double[10];
            double gammaT_x = 0;
            double gammaT_y = 0;
            double gammaC_x = 0;
            double gammaC_y = 0;
            double freq = 2.4;
            //errorCode = MauryTunerFunctions.get_tuner_refl_data(tunerNumber, 0, freq, gammaC_x, gammaC_y, gammaT_x, gammaT_y, carr, p1, p2,
             //                                       s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, s22_x, s22_y, error);
            if (errorCode != 0)
            {
                throw new Exception(new string(error));
            }
            try
            {
                errorCode = MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, error);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (errorCode != 0)
            {
                throw new Exception(new string(error));
            }

        }

        public void deinitTuner()
        {
            char[] error = new char[100];
            int errorCode = MauryTunerFunctions.delete_tuner_ex(tunerNumber, error);
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }
            errorCode = MauryTunerFunctions.delete_controller_ex(controllerNumber, error);  
            if (errorCode != 0)
            {
                Console.WriteLine(error);
                throw new Exception(error.ToString());
            }

        }

        public void moveTunerToImpedance(string tunerDataFilePath, Complex impedance, double freq)
        {

            char[] error = new char[100];
            var err = MauryTunerFunctions.read_tuner_data_file(tunerNumber, tunerDataFilePath.ToCharArray(), model, error);
            if(err != 0)
            {
                throw new Exception(new string(error));
            }
            Complex Z0= new Complex(50,0);
            Complex gamma = (impedance - Z0) / (impedance + Z0);

            Complex target = (gamma - sParams[0])/(sParams[4]*(gamma-sParams[4])+sParams[2]*sParams[1]);

            long carr = 0;
            long p1 = 0;
            long p2 = 0;
            double[] dummy = new double[3];
            err = MauryTunerFunctions.get_tuner_refl_data(tunerNumber, 0, freq, 0, 0, target.Real, target.Imaginary, carr, p1, p2,
                                                    dummy, dummy, dummy, dummy, dummy, dummy, dummy, dummy, error);
            if (err != 0)
            {
                throw new Exception(new string(error));
            }
            err = MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, error);
            if (err != 0)
            {
                throw new Exception(new string(error));
            }
        }

        public void moveTunerToSmithPosition(Complex position, double freq)
        {
            Complex target = (position - sParams[0]) / (sParams[4] * (position - sParams[4]) + sParams[2] * sParams[1]);

            char[] error = new char[100];
            long carr = 0;
            long p1 = 0;
            long p2 = 0;
            double[] dummy = new double[3];
            MauryTunerFunctions.get_tuner_refl_data(tunerNumber, 0, freq, 0, 0, target.Real, target.Imaginary, carr, p1, p2,
                                                    dummy, dummy, dummy, dummy, dummy, dummy, dummy, dummy, error);

            MauryTunerFunctions.move_tuner(tunerNumber, carr, p1, p2, error);
        }
    }
}
