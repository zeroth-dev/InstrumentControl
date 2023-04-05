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

            char[] error = new char[10000];
            int err_code = MauryTunerFunctions.add_tuner_ex(0, driverPath.ToCharArray(), tunerModel.ToCharArray(), 1333, 3, error);
            if(err_code != 0) Console.WriteLine(error);
            Console.WriteLine("Added tuner, adding controller");

            err_code = MauryTunerFunctions.add_controller_ex(0, driverModel.ToCharArray(), 0, 2, 0, 3, 0, (short)2048, error);

            if (err_code != 0) Console.WriteLine(error);
            Console.WriteLine("Added tuner, loading file");
            int[] max_range = new int[3];
            double[] fmin = new double[1];
            double[] fmax = new double[1];
            double[] fcrossover = new double[1];
            err_code = MauryTunerFunctions.read_tuner_data_file(0, tunerCharPath.ToCharArray(), tunerModel.ToCharArray(), error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.move_tuner(0, 150, 1234, 1700, error);

            err_code = MauryTunerFunctions.add_tuner_ex(1, driverPath.ToCharArray(), tunerModel.ToCharArray(), 1331, 3, error);
            if (err_code != 0) Console.WriteLine(error);
            err_code = MauryTunerFunctions.add_controller_ex(1, driverModel.ToCharArray(), 0, 1, 0, 3, 0, (short)2048, error);
            if (err_code != 0) Console.WriteLine(error);

            err_code = MauryTunerFunctions.move_tuner(1, 150, 1234, 1700, error);


        }
    }
}