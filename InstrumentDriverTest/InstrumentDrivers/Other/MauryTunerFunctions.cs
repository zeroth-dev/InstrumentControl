﻿using System;
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
        public static extern short add_controller_ex(short tuner_number, [In] char[] model, int ctrl_num, int ctrl_port, int timeout,
                                                int address, int delay_ms, short serial_number, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "add_tuner_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short add_tuner_ex(short tuner_number, char[] driver, char[] model,
                                                short serial_number, int address, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "read_tuner_data_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short read_tuner_data_file(short tuner_number,
                                                        [In] char[] fname, [In] char[] tuner_model, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_refl_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_refl_data(short tuner_number,
                                                        short interp_mode, double freq, double gamma_termination_x,
                                                        double gamma_termination_y, double gamma_target_x, double gamma_target_y,
                                                        ref int carr, ref int p1, ref int p2, [Out] double[] s11_x, [Out] double[] s11_y,
                                                        [Out] double[] s21_x, [Out] double[] s21_y, [Out] double[] s12_x, [Out] double[] s12_y,
                                                        [Out] double[] s22_x, [Out] double[] s22_y, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_tuner_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short delete_tuner_ex(short tuner_number, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "delete_controller_ex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short delete_controller_ex(short controller_number, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "init_tuners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short init_tuners([Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_position(short tuner_number, ref int carr,
                                                        ref int p1, ref int p2, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_position_spara", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_position_spara(short tuner_number,
                                                            double freq, short interp_mode, ref int carr, ref int p1, ref int p2,
                                                            [Out] double[] s11_x, [Out] double[] s11_y, [Out] double[] s21_x, [Out] double[] s21_y,
                                                            [Out] double[] s12_x, [Out] double[] s12_y, [Out] double[] s22_x, [Out] double[] s22_y,
                                                            [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_freqs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_freqs(short tuner_number, [Out] short numfreq, [Out] double[] freqs, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "move_tuner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short move_tuner(short tuner_number, int carr, int p1, int p2, [Out] char[] error_string);

        [DllImport("MLibTuners.dll", EntryPoint = "get_tuner_init_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short get_tuner_init_status(short tuner_number, ref short status, [Out] char[] error_string);


        [DllImport("MLibTuners.dll", EntryPoint = "isthere_tuners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short isthere_tuners(char[] error_string);
    }
}