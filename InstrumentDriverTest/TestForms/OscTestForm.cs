using InstrumentDriverTest.Instruments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                var (time, amp) = oscilloscope.GetNormalMeasurement(channel);
                using (StreamWriter writer = new StreamWriter(@"NormalOutput_time.csv"))
                {
                    foreach (double item in time)
                    {
                        writer.WriteLine(item); //note the F9
                    }
                };
                using (StreamWriter writer = new StreamWriter(@"NormalOutput_volt.csv"))
                {
                    foreach (double item in amp)
                    {
                        writer.WriteLine(item); //note the F9
                    }
                };
                var chart = new ChartForm(time, amp);
                chart.Show();
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
            SendCmdBtn.Enabled = enable;
        }

        private void PlotData(List<double> x, List<double> y)
        {
            Chart chart = new Chart();
            DataTable dt = new DataTable();
            dt.Columns.Add("Time", typeof(double));
            dt.Columns.Add("Voltage", typeof(double));
            for(int i = 0; i < x.Count; i++)
            {
                dt.Rows.Add(x[i], y[i]);
            }
            chart.DataSource = dt;
            chart.Series["Series1"].XValueMember = "Time";
            chart.Series["Series1"].YValueMembers = "Voltage";
            chart.Series["Series1"].ChartType = SeriesChartType.Line;
        }

    }
}
