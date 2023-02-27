using InstrumentDriverTest.Instruments;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentDriverTest.TestForms
{
    public partial class RFSrcTest : Form
    {
        private E44xxB rfSource = null;
        public RFSrcTest()
        {
            InitializeComponent();
            InitFreqBandList();
        }

        private void InitFreqBandList()
        {
            string[] list = { "Hz", "kHz", "MHz", "GHz" };
            FreqBandBox.Items.AddRange(list);
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceList = Instruments.VisaUtil.GetConnectedDeviceList();
                InstrumentList.Items.Add(deviceList);
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
                rfSource = new E44xxB(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableBtns(true);
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text);
                rfSource.setCWFrequency(freq, FreqBandBox.Text);

                double power = double.Parse(PowerBox.Text);
                rfSource.setCWPower(power);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rfSource.turnOn();
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOffBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rfSource.turnOff();
            }
            catch (Exception ex)
            {
                LogBox.AppendText (ex.Message + Environment.NewLine);
            }
        }

        private void SendCmdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var output = Instruments.VisaUtil.SendReceiveStringCmd(rfSource.visa, CmdBox.Text);
                LogBox.AppendText(output + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void EnableBtns(bool enable)
        {
            ApplyBtn.Enabled = enable;
            TurnOffBtn.Enabled = enable;
            TurnOnBtn.Enabled = enable;
        }
    }
}
