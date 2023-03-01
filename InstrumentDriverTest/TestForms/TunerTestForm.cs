﻿using InstrumentDriverTest.Instruments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentDriverTest.TestForms
{
    public partial class TunerTestForm : Form
    {

        MauryTunerDriver tuner;

        public TunerTestForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CtrlDriverBox.Text = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll";
            TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InstrumentList.Items.Clear();
                var deviceList = Instruments.VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    InstrumentList.Items.Add(device);
                }
                InstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = InstrumentList.Text;
            try
            {
                tuner = new MauryTunerDriver(2, 0, 1333, 2048, 2, 3);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableBtns(true);
        }

        private void BrowseCtrlDriverPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Controller driver";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                CtrlDriverBox.Text = fbd.SelectedPath;
            }
        }

        private void BrowseTunerCharFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Controller driver";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TunerCharFileBox.Text = fbd.SelectedPath;
            }

        }

        private void MoveTunerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "CppDllTest.exe";
                    string arguments = "\"" + CtrlDriverBox.Text + "\" \"" + TunerCharFileBox.Text + "\" " + ZRealBox.Text + " " + ZImagBox.Text + " true";
                    p.StartInfo.Arguments = arguments;
                    p.StartInfo.CreateNoWindow = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.Start();

                    while (!p.StandardOutput.EndOfStream)
                    {
                        string line = p.StandardOutput.ReadLine();
                        LogBox.AppendText(line+ Environment.NewLine);
                        // do something with line
                    }
                }
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }

        private void SendCmdBtn_Click(object sender, EventArgs e)
        {

        }

        void EnableBtns(bool enable)
        {
            BrowseTunerCharFileBtn.Enabled = enable;
            BrowseCtrlDriverPathBtn.Enabled = enable;
            MoveTunerBtn.Enabled = enable;
            SendCmdBtn.Enabled = enable;
        }
    }
}
