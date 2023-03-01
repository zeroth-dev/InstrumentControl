using InstrumentDriverTest.Instruments;
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

        List<MauryTunerDriver> tuners;

        public TunerTestForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CtrlDriverBox.Text = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll";
            TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";

            string tunerModel = "MT982EU30";
            // Model used is MT986B02 
            string ctrlModel = "MT986B02";
            tuners = new List<MauryTunerDriver>();
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
