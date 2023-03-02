using InstrumentDriverTest.Instruments;
using InstrumentDriverTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentDriverTest.TestForms
{
    public partial class SATestForm : Form
    {

        N9000A spectrumAnalyzer;

        NumberFormatInfo provider = new NumberFormatInfo();
        public SATestForm()
        {
            InitializeComponent();
            InitFreqBandList();
            provider.NumberDecimalSeparator = ".";
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
                spectrumAnalyzer = new N9000A(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double baseFreq = double.Parse(FreqBox.Text, provider);
            double freq_2 = 2 * baseFreq;
            double freq_3 = 3 * baseFreq;

            double pow_1 = spectrumAnalyzer.MeasPeak(baseFreq, FreqBandBox.Text);
            double pow_2 = spectrumAnalyzer.MeasPeak(freq_2, FreqBandBox.Text);
            double pow_3 = spectrumAnalyzer.MeasPeak(freq_3, FreqBandBox.Text);

            BaseHarmBox.Text = pow_1.ToString();
            ScndHarmBox.Text = pow_2.ToString();
            TrdHarmBox.Text = pow_3.ToString();
        }
    }
}
