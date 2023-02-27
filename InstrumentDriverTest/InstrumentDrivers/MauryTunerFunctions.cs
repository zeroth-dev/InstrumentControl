using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.Instruments
{
    internal class MauryTunerFunctions
    {
        [DllImport("MLibTuners.dll", EntryPoint = "add_controller", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short add_controller(short controller_number,
                                                char[] driver, char[] model, int timeout, int address, long delay_ms,
                                                short serial_number, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "add_tuner", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short add_tuner(short tuner_number, char[] model,
                                            short serial_number, short ctlr_num, short ctlr_port, out short no_of_motors,
                                            out long[] max_range, out double fmin, out double fmax, out double fcrossover,
                                            out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "read_tuner_data_file", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short read_tuner_data_file(short tuner_number,
                                                        char[] fname, char[] tuner_model, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_refl_data", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_refl_data(short tuner_number,
                                                        short interp_mode, double freq, double gamma_termination_x,
                                                        double gamma_termination_y, double gamma_target_x, double gamma_target_y,
                                                        out long carr, out long p1, out long p2, out double[] s11_x, out double[] s11_y,
                                                        out double[] s21_x, out double[] s21_y, out double[] s12_x, out double[] s12_y,
                                                        out double[] s22_x, out double[] s22_y, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_tuner_ex", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short delete_tuner_ex(short tuner_number, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_controller_ex", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short delete_controller_ex(short controller_number, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_position(short tuner_number, out long carr, 
                                                        out long p1, out long p2, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position_spara", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_position_spara(short tuner_number,
                                                            double freq, short interp_mode, out long carr, out long p1, out long p2,
                                                            out double s11_x, out double[] s11_y, out double[] s21_x, out double[] s21_y,
                                                            out double s12_x, out double s12_y, out double[] s22_x, out double[] s22_y,
                                                            out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_freqs", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_freqs(short tuner_number, out short numfreq, out double[] freqs, out char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "move_tuner", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern short move_tuner(short tuner_number, long carr, long p1, long p2, out char[] error_string);
    }
}
