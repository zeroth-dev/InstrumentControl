using InstrumentDriverTest.Instruments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                tuner = new MauryTunerDriver(2, 0, 1333, 2048, 2, 3);
                tuner.initTuner(CtrlDriverBox.Text);
                Complex impedance = new Complex(double.Parse(ZRealBox.Text, CultureInfo.InvariantCulture.NumberFormat),
                                                double.Parse(ZImagBox.Text, CultureInfo.InvariantCulture.NumberFormat));
                tuner.moveTunerToImpedance(TunerCharFileBox.Text, impedance, 2.4);
                tuner.deinitTuner();
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
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
