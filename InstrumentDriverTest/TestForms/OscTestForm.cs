using InstrumentDriverTest.InstrumentDrivers;
using InstrumentDriverTest.InstrumentDrivers.Oscilloscope;
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

        Oscilloscope oscilloscope;

        List<double> xAxis = new List<double>();
        List<double> yAxis = new List<double>();

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InstrumentList.Items.Clear();
                var deviceList = InstrumentDrivers.VisaUtil.GetConnectedDeviceList();
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
                oscilloscope = new MSO7034B(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableBtns(true);
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            if (ChannelBox.Text.Length == 0)
            {
                LogBox.AppendText("Channel entry cannot be empty");
                return;
            }
            try
            {
                var channel = int.Parse(ChannelBox.Text);
                Oscilloscope.AcquisitionType acqType = AvgTypeBtn.Checked ? Oscilloscope.AcquisitionType.AVERAGE : Oscilloscope.AcquisitionType.NORMAL;
                UInt16 count = 0;
                if(acqType == Oscilloscope.AcquisitionType.AVERAGE)
                {
                    count = UInt16.Parse(AvgNoBox.Text);
                }
                var (xAxis, yAxis) = oscilloscope.GetWaveform(channel, acqType, count);
                using (StreamWriter writer = new StreamWriter(@"NormalOutput_time.csv"))
                {
                    foreach (double item in xAxis)
                    {
                        writer.WriteLine(item); //note the F9
                    }
                };
                using (StreamWriter writer = new StreamWriter(@"NormalOutput_volt.csv"))
                {
                    foreach (double item in yAxis)
                    {
                        writer.WriteLine(item); //note the F9
                    }
                };
                var chart = new ChartForm(xAxis, yAxis);
                chart.Show();
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void GetFFTBtn_Click(object sender, EventArgs e)
        {
            if (ChannelBox.Text.Length == 0)
            {
                LogBox.AppendText("Channel entry cannot be empty");
                return;
            }
            try
            {
                var channel = int.Parse(ChannelBox.Text);
                Oscilloscope.AcquisitionType acqType = AvgTypeBtn.Checked ? Oscilloscope.AcquisitionType.AVERAGE : Oscilloscope.AcquisitionType.NORMAL;
                UInt16 count = 0;
                if (acqType == Oscilloscope.AcquisitionType.AVERAGE)
                {
                    count = UInt16.Parse(AvgNoBox.Text);
                }
                var (xAxis, yAxis) = oscilloscope.GetWaveform(channel, acqType, count);
                
                var chart = new ChartForm(xAxis, yAxis);
                chart.Show();
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

        private void AvgTypeBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (AvgTypeBtn.Checked)
            {
                AvgNoBox.Enabled = true;
            }
            else
            { 
                AvgNoBox.Enabled = false;
            }
        }

        private void BrowseOscSavePathBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Oscilloscope image";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImgSavePathBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void BrowseOscDataPathBox_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Oscilloscope data";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataFilePathBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void BrowseFFTPathBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Oscilloscope data";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FFTSavePathBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void SaveImgBtn_Click(object sender, EventArgs e)
        {
            if(ImgSavePathBox.Text == "")
            {
                LogBox.AppendText("Please enter path for the image" + Environment.NewLine);
                return;
            }
            var img = oscilloscope.GetImage();
            File.WriteAllBytes(ImgSavePathBox.Text, img);
        }

        private void SaveOscDataBtn_Click(object sender, EventArgs e)
        {
            if (DataFilePathBox.Text == "")
            {
                LogBox.AppendText("Please enter path for the data" + Environment.NewLine);
                return;
            }
            using (StreamWriter writer = new StreamWriter(DataFilePathBox.Text))
            {
                for(int i = 0; i < yAxis.Count; i++)
                {
                    writer.WriteLine(xAxis[i] + " " + yAxis[i]);
                }
            };

        }

        private void SaveFFTDataBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
