using InstrumentDriverTest.Instruments;
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
    public partial class OscTestForm : Form
    {
        public OscTestForm()
        {
            InitializeComponent();
        }

        HP5412x oscilloscope;

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
                oscilloscope = new HP5412x(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableBtns(true);
        }

        private void GetNormDataBtn_Click(object sender, EventArgs e)
        {
            if (ChannelBox.Text.Length == 0)
            {
                LogBox.AppendText("Channel entry cannot be empty");
                return;
            }
            try
            {
                var channel = int.Parse(ChannelBox.Text);
                oscilloscope.GetNormalMeasurement(channel);
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void GetAvgDataBtn_Click(object sender, EventArgs e)
        {
            if (ChannelBox.Text.Length == 0 || AvgNoBox.Text.Length == 0)
            {
                LogBox.AppendText("Channel and number of averages entries cannot be empty");
                return;
            }
            try
            {
                var channel = int.Parse(ChannelBox.Text);
                var avgCount = int.Parse(AvgNoBox.Text);
                oscilloscope.GetAveragedMeasurement(channel, avgCount);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void EnableBtns(bool enable)
        {
            GetNormDataBtn.Enabled = enable;
            GetAvgDataBtn.Enabled = enable;
            SendCmdBtn.Enabled = enable;
        }

    }
}
