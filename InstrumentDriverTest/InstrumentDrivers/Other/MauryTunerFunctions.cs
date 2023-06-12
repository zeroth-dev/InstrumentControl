using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.Other
{
    public class MauryTunerFunctions
    {
        [DllImport("MLibTuners.dll", EntryPoint = "add_controller_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 add_controller_ex(Int16 tuner_number, [In] char[] model, Int32 ctrl_num, Int32 ctrl_port, Int32 timeout,
                                                Int32 address, Int32 delay_ms, Int16 serial_number, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "add_tuner_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 add_tuner_ex(Int16 tuner_number, char[] driver, char[] model,
                                                Int16 serial_number, Int32 address, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "read_tuner_data_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 read_tuner_data_file(Int16 tuner_number,
                                                        [In] char[] fname, [In] char[] tuner_model, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_refl_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 get_tuner_refl_data(Int16 tuner_number,
                                                        Int16 interp_mode, double freq, double gamma_termination_x,
                                                        double gamma_termination_y, double gamma_target_x, double gamma_target_y,
                                                        ref Int32 carr, ref Int32 p1, ref Int32 p2, [Out] double[] s11_x, [Out] double[] s11_y,
                                                        [Out] double[] s21_x, [Out] double[] s21_y, [Out] double[] s12_x, [Out] double[] s12_y,
                                                        [Out] double[] s22_x, [Out] double[] s22_y, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_tuner_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 delete_tuner_ex(Int16 tuner_number, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_controller_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 delete_controller_ex(Int16 controller_number, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "init_tuners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 init_tuners([Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 get_tuner_position(Int16 tuner_number, ref Int32 carr,
                                                        ref Int32 p1, ref Int32 p2, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position_spara", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 get_tuner_position_spara(Int16 tuner_number,
                                                            double freq, Int16 interp_mode, ref Int32 carr, ref Int32 p1, ref Int32 p2,
                                                            [Out] double[] s11_x, [Out] double[] s11_y, [Out] double[] s21_x, [Out] double[] s21_y,
                                                            [Out] double[] s12_x, [Out] double[] s12_y, [Out] double[] s22_x, [Out] double[] s22_y,
                                                            [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_freqs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 get_tuner_freqs(Int16 tuner_number, [Out] Int16 numfreq, [Out] double[] freqs, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "move_tuner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 move_tuner(Int16 tuner_number, Int32 carr, Int32 p1, Int32 p2, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_init_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 get_tuner_init_status(Int16 tuner_number, ref Int16 status, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "isthere_tuners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 isthere_tuners(char[] error_string);
    }
}
