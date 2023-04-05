using InstrumentDriverTest.Instruments;
using System.Runtime.InteropServices;

namespace TunerTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Adding Controller:");
            /*
#define CTRL_MODEL "MT986B02"
#define CTRL_SERIAL 2048
#define TUNER_MODEL "MT982EU30"
#define OUTPUT_TUNER 1333
#define INPUT_TUNER 1331
#define OUTPUT_PORT 2
#define INPUT_PORT 1
            */
            string driverPath = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll\0";
            string driverModel = "MT986B02\0";
            string tunerModel = "MT982EU30\0";
            string tunerCharPath= "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun\0";
            string inTunerCharPath = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\load_pull_source_2_4_GHz_DEE.tun\0";

            char[] error = new char[10000];
            int err_code = MauryTunerFunctions.add_tuner_ex(0, driverPath.ToCharArray(), tunerModel.ToCharArray(), 1331, 3, error);
            if(err_code != 0) Console.WriteLine(error);
            err_code = MauryTunerFunctions.read_tuner_data_file(0, tunerCharPath.ToCharArray(), tunerModel.ToCharArray(), error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.add_controller_ex(0, driverModel.ToCharArray(), 0, 1, 0, 3, 0, (short)2048, error);

            err_code = MauryTunerFunctions.isthere_tuners(error);
            Console.WriteLine("Is there tuners: " + err_code);

            err_code = MauryTunerFunctions.init_tuners(error);
            if (err_code != 0) Console.WriteLine(error);

            Console.WriteLine("Added tuner, adding controller");


            if (err_code != 0) Console.WriteLine(error);
            Console.WriteLine("Added tuner, loading file");
            int[] max_range = new int[3];
            double[] fmin = new double[1];
            double[] fmax = new double[1];
            double[] fcrossover = new double[1];
            err_code = MauryTunerFunctions.move_tuner(0, 150, 1234, 1700, error);

            err_code = MauryTunerFunctions.delete_tuner_ex(0, error);

            err_code = MauryTunerFunctions.add_tuner_ex(0, driverPath.ToCharArray(), tunerModel.ToCharArray(), 1333, 3, error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.read_tuner_data_file(0, inTunerCharPath.ToCharArray(), tunerModel.ToCharArray(), error);
            if (err_code != 0) Console.WriteLine(error);

            //err_code = MauryTunerFunctions.init_tuners(error);
            err_code = MauryTunerFunctions.add_controller_ex(0, driverModel.ToCharArray(), 0, 2, 0, 3, 0, (short)2048, error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.init_tuners(error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.move_tuner(0, 150, 1234, 1700, error);

            err_code = MauryTunerFunctions.add_tuner_ex(1, driverPath.ToCharArray(), tunerModel.ToCharArray(), 1331, 3, error);
            if (err_code != 0) Console.WriteLine(error);
            err_code = MauryTunerFunctions.read_tuner_data_file(1, tunerCharPath.ToCharArray(), tunerModel.ToCharArray(), error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.add_controller_ex(1, driverModel.ToCharArray(), 0, 1, 0, 3, 0, (short)2048, error);


            err_code = MauryTunerFunctions.move_tuner(1, 150, 1234, 1700, error);

            int carr = 0;
            int p1 = 0;
            int p2 = 0;
            err_code = MauryTunerFunctions.get_tuner_position(1, ref carr, ref p1, ref p2, error);
            if (err_code != 0) Console.WriteLine(error);
            else
            {
                Console.WriteLine("Position: carr " + carr + ", p1 " + p1 + ", p2 " + p2);
            }


            //err_code = MauryTunerFunctions.move_tuner(1, 500, 1234, 1700, error);
            if (err_code != 0) Console.WriteLine(error);
            err_code = MauryTunerFunctions.get_tuner_position(1, ref carr, ref p1, ref p2, error);
            if (err_code != 0) Console.WriteLine(error);
            else
            {
                Console.WriteLine("Position: carr " + carr + ", p1 " + p1 + ", p2 " + p2);
            }

            double[] s11_x = new double[10];
            double[] s11_y = new double[10];
            double[] s21_x = new double[10];
            double[] s21_y = new double[10];
            double[] s12_x = new double[10];
            double[] s12_y = new double[10];
            double[] s22_x = new double[10];
            double[] s22_y = new double[10];

            err_code = MauryTunerFunctions.get_tuner_refl_data(1, 0, 2.4, 0, 0, 0, 0, ref carr, ref p1, ref p2, s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, s22_x, s22_y, error);

            err_code = MauryTunerFunctions.get_tuner_position_spara(1, 2.4, 0, ref carr, ref p1, ref p2, s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, s22_x, s22_y, error);

            if (err_code != 0) Console.WriteLine(error);

            return;


        }
    }
}