using InstrumentDriverTest.InstrumentDrivers;
using InstrumentDriverTest.InstrumentDrivers.DCPowerSupply;
using InstrumentDriverTest.InstrumentDrivers.RFSource;
using InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tone_2Test.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Tone_2Test
{
    public partial class Tone_2Test_Form : Form
    {

        DCPowerSupply dcPowerSupply;
        RFSource rfSource1;
        RFSource rfSource2;
        SpectrumAnalyzer spectrumAnalyzer;
        int count = 0; 
        
        CancellationTokenSource tokenSource;
        CancellationToken token;

        NumberFormatInfo provider = new NumberFormatInfo();
        public Tone_2Test_Form()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
        }

        private void RefreshListBtn_Click(object sender, EventArgs e)
        {

            try
            {
                DCInstrumentList.Items.Clear();
                RF1InstrumentList.Items.Clear();
                RF2InstrumentList.Items.Clear();
                SAInstrumentList.Items.Clear();
                var deviceList = VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                    RF1InstrumentList.Items.Add(device);
                    RF2InstrumentList.Items.Clear();
                    SAInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
                RF1InstrumentList.SelectedIndex = 0;
                RF2InstrumentList.Items.Clear();
                SAInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void ConnectDCBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = DCInstrumentList.Text;
            try
            {
                dcPowerSupply = new E364xA_2(gpibAddress);
                LogText("Registered device:");
                LogText(dcPowerSupply.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

            EnableDcBtns(true);
        }

        private void ConnectRF1Btn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RF1InstrumentList.Text;
            try
            {
                rfSource1 = new E44xxB(gpibAddress);
                LogText("Registered device:");
                LogText(rfSource1.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

        }

        private void ConnectRF2Btn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RF2InstrumentList.Text;
            try
            {
                rfSource2 = new E44xxB(gpibAddress);
                LogText("Registered device:");
                LogText(rfSource2.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

        }

        private void ConnectSABtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = SAInstrumentList.Text;
            try
            {
                spectrumAnalyzer = new N9000A(gpibAddress);
                LogText("Registered device:");
                LogText(spectrumAnalyzer.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
        }

        private void ApplyDCSrc1btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogText("DC power supply  not initialized!");
                return;
            }

            try
            {
                double voltage = double.Parse(Src1VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(1, voltage);
                double current = double.Parse(Src1CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(1, current);
                LogText("Set voltage and current limit for source 1");
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
        }

        private void ApplyDCSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogText("DC power supply not initialized!");
                return;
            }

            try
            {
                double voltage = double.Parse(Src2VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(2, voltage);
                double current = double.Parse(Src2CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(2, current);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }
        }

        private void TurnOnDCSrc1Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("DC power supply not initialized!\n");
                return;
            }
            try
            {
                bool turnOn = !dcPowerSupply.IsTurnedOn(0);
                dcPowerSupply.TurnOnOff(1, turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrc1Btn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOnDCSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("DC power supply not initialized!\n");
                return;
            }
            try
            {
                bool turnOn = !dcPowerSupply.IsTurnedOn(1);
                dcPowerSupply.TurnOnOff(2, turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrc1Btn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void ApplyRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text, provider);
                rfSource1.SetCWFrequency(freq, "GHz");

                double offset = double.Parse(OffsetFreqBox.Text, provider);
                rfSource2.SetCWFrequency(freq - offset/1000.0f, "GHz");

                double inputPower = double.Parse(StartBox.Text, provider);
                double gain = 0;
                if (PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource1.SetCWPower(inputPower - gain);
                rfSource2.SetCWPower(inputPower - gain);
                LogText(String.Format("Set RF frequency {0} {1} and power {2} dBm",
                                        freq.ToString(provider), "GHz", (inputPower - gain).ToString(provider)));

                spectrumAnalyzer.SetCentralFrequency(freq, "GHz");

                double span = double.Parse(SpanBox.Text, provider);
                spectrumAnalyzer.SetSpan(span, "MHz");

                double bw = double.Parse(BWBox.Text, provider);
                spectrumAnalyzer.SetBW(bw, "kHz");

            }
            catch (Exception ex)
            {
                LogText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOnRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool turnOn = !rfSource1.turnedOn;
                rfSource1.TurnOnOff(turnOn);
                rfSource2.TurnOnOff(turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrc1Btn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            // Setup
            if (dcPowerSupply == null || spectrumAnalyzer == null || rfSource1 == null || rfSource2 == null)
            {
                LogText("Please initialise all devices before starting the program");
            }


            // TODO: Create meaningful filename
            string filename = "Output.txt";
            if (FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }

            if (CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }

            double attenuation = 0;
            if (AttBox.Text != "")
            {
                attenuation = double.Parse(AttBox.Text, provider);
            }

            double gain = 0;
            if (PreampGainBox.Text != "")
            {
                gain = double.Parse(PreampGainBox.Text, provider);
            }

            if (CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }
            double freq = double.Parse(CWFreqBox.Text, provider);
            double offset = double.Parse(OffsetFreqBox.Text, provider);
            string freqBand = "GHz";

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("Vg, Vd, Id, Pin, Pout1, Pout2, Pout3");
            }

            double startPower = double.Parse(StartBox.Text, provider);
            double endPower = double.Parse(StopBox.Text, provider);
            double step = double.Parse(StepBox.Text, provider);

            count = (int)((endPower - startPower) / step);

            ProgressLabel.Text = "0/" + count;
            rfSource1.TurnOnOff(true);
            rfSource2.TurnOnOff(true);
            dcPowerSupply.TurnOnOff(1, true);
            dcPowerSupply.TurnOnOff(2, true);

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                IteratePower(filename, freq, freqBand, offset, startPower, endPower, step, attenuation, gain, token);
            }).ContinueWith(_ => { IterationDone(); });
        }


        public void IteratePower(string filename, double freq, string freqBand, double offset, double startPower, double endPower, double step,
                                            double attenuation, double gain, CancellationToken ct)
        {
            int progress = 0;
            for (double power = startPower; power <= endPower; power += step)
            {
                rfSource1.SetCWPower(power - gain);
                rfSource2.SetCWPower(power - gain);

                // Read three harmonics of the output signal and the power supply readings
                double basePwr, secondPwr, thirdPwr, Vd, Id, Vg;
                (basePwr, secondPwr, thirdPwr, Vd, Id, Vg) = ReadData(freq, freqBand, offset, attenuation);

                OutputData(filename, Vg, Vd, Id, power, basePwr, secondPwr, thirdPwr);
                progress++;
                UpdateProgress(progress, count);

                if (ct.IsCancellationRequested)
                {
                    rfSource1.TurnOnOff(false);
                    rfSource2.TurnOnOff(false);
                    dcPowerSupply.TurnAllOnOff(false);
                    return;
                }

            }

            rfSource1.TurnOnOff(false);
            rfSource2.TurnOnOff(false);
            dcPowerSupply.TurnOnOff(1, false);
            dcPowerSupply.TurnOnOff(2, false);
        }

        private (double, double, double, double, double, double) ReadData(double freq, string freqBand, double offset, double attenuation)
        {
            double basePwr = spectrumAnalyzer.MeasAtFrequency(freq, freqBand) + attenuation;
            double secondPwr = spectrumAnalyzer.MeasAtFrequency(freq + offset/1000.0f, freqBand) + attenuation;
            double thirdPwr = spectrumAnalyzer.MeasAtFrequency(freq + 2*(offset / 1000.0f), freqBand) + attenuation;

            SetText(BaseHarmBox, basePwr.ToString());
            SetText(ScndHarmBox, secondPwr.ToString());
            SetText(TrdHarmBox, thirdPwr.ToString());

            double Vg = dcPowerSupply.ReadVoltage(1);
            double Vd = dcPowerSupply.ReadVoltage(2);
            double Id = dcPowerSupply.ReadCurrent(2);

            return (basePwr, secondPwr, thirdPwr, Vd, Id, Vg);


        }

        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
            control.Text = text;
        }

        private void OutputData(string filename, double vg, double vd, double id, double powerIn, double baseHarmPwr,
                                double scndHarmPwr, double TrdHarmPwr)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            vg, vd, id, powerIn, baseHarmPwr, scndHarmPwr,
                                            TrdHarmPwr));
            }
        }

        private void UpdateProgress(int done, int total)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<int, int>(UpdateProgress), done, total);
            }
            ProgressLabel.Text = String.Format("{0}/{1}", done, total);
        }

        private void IterationDone()
        {
            LogText("Process was completed");

            rfSource1.TurnOnOff(false);
            rfSource2.TurnOnOff(false);
            dcPowerSupply.TurnOnOff(2, false);
            dcPowerSupply.TurnOnOff(1, false);
        }

        private void EnableDcBtns(bool enable)
        {
            ApplyDCSrc1btn.Enabled = enable;
            ApplyDCSrc2Btn.Enabled = enable;
            TurnOnDCSrc1Btn.Enabled = enable;
            TurnOnDCSrc2Btn.Enabled = enable;
        }

        private void LogText(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogText), msg);
                return;
            }
            LogBox.AppendText(msg + Environment.NewLine);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void BrowseSaveFileBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "De-embedding data";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileNameBox.Text = saveFileDialog.FileName;
                }
            }
        }
    }
}
