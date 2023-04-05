using InstrumentDriverTest.Instruments;
using System.Runtime.InteropServices;

namespace TunerTesting
{
    internal class Program
    {

        [DllImport("MLibTuners.dll", EntryPoint = "add_controller", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, SetLastError =true)]
        public static extern short add_controller(short controller_number,
                                                [In] char[] driver, [In] char[] model, int timeout, int address, int delay_ms,
                                                short serial_number, [Out] char[] error_string);

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
            string driverModel = "MT986B02";
            string tunerCharPath= "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun\0";

            char[] error = new char[1000];
            add_controller(0, driverPath.ToCharArray(), driverModel.ToCharArray(), 0, 3, 0, 2048, error);
            int err_coe = Marshal.GetLastWin32Error();
            Console.WriteLine("Win32 error: ", err_coe);
            Console.WriteLine(error);
            Console.WriteLine("Added controller, adding tuner");
        }
    }
}