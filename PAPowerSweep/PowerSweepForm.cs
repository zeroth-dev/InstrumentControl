using InstrumentDriverTest.InstrumentDrivers;
using InstrumentDriverTest.Instruments;
using PAPowerSweep.Properties;
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

namespace PAPowerSweep
{
    public partial class PowerSweepForm : Form
    {

        E36300 dcPowerSupply;
        HP8350B rfSource;
        MS710 spectrumAnalyzer;
        int count = 0;

        NumberFormatInfo provider = new NumberFormatInfo();

        public PowerSweepForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
            InitFreqBandList();
        }


        /////////////////////////////////////////////////////////
        /////////////  DC Power Supply Controls  ////////////////
        /////////////////////////////////////////////////////////

        private void ConnectDCBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = DCInstrumentList.Text;
            try
            {
                dcPowerSupply = new E36300(gpibAddress);
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

        private void TurnOnDC1SrcBtn_Click(object sender, EventArgs e)
        {

            if (dcPowerSupply == null)
            {
                LogBox.AppendText("DC power supply not initialized!\n");
                return;
            }
            try
            {
                bool turnOn = !dcPowerSupply.turnedOn[0];
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
                bool turnOn = !dcPowerSupply.turnedOn[1];
                dcPowerSupply.TurnOnOff(2, turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrc1Btn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void EnableDcBtns(bool enable)
        {
            ApplyDCSrc1btn.Enabled = enable;
            ApplyDCSrc2Btn.Enabled = enable;
            TurnOnDCSrc1Btn.Enabled = enable;
            TurnOnDCSrc2Btn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  DC Power Supply Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        /////////////    RF Power Source Controls   /////////////
        /////////////////////////////////////////////////////////

        private void ConnectRFBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RFInstrumentList.Text;
            try
            {
                rfSource = new HP8350B(gpibAddress);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

            EnableRFBtns(true);
        }


        private void ApplyRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text, provider);
                rfSource.SetCWFrequency(freq, FreqBandBox.Text);

                double inputPower = double.Parse(StartBox.Text, provider);
                double gain = 0;
                if (PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource.SetCWPower(inputPower - gain);
                LogText(String.Format("Set RF frequency {0} {1} and power {2} dBm",
                                        freq.ToString(provider), FreqBandBox.Text, (inputPower - gain).ToString(provider)));
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
                bool turnOn = !rfSource.turnedOn;
                rfSource.TurnOnOff(turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrc1Btn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void InitFreqBandList()
        {
            string[] list = { "Hz", "kHz", "MHz", "GHz" };
            FreqBandBox.Items.AddRange(list);
        }

        private void EnableRFBtns(bool enable)
        {
            TurnOnRFBtn.Enabled = enable;
            ApplyRFBtn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  RF Power Source Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        /////////    Spectrum Analyzer Controls   ///////////////
        /////////////////////////////////////////////////////////

        private void ConnectSABtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = SAInstrumentList.Text;
            try
            {
                spectrumAnalyzer = new MS710(gpibAddress);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
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

        private void BrowseSaveFileBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "De-embedding data";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileNameBox.Text= saveFileDialog.FileName;
                }
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            // Setup
            if (dcPowerSupply == null || spectrumAnalyzer == null || rfSource == null)
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
            if(PreampGainBox.Text != "")
            {
                gain = double.Parse(PreampGainBox.Text, provider);
            }

            if (CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }
            double freq = double.Parse(CWFreqBox.Text, provider);

            string freqBand = FreqBandBox.Text;

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("Vg, Vd, Id, Pin, Pout1, Pout2, Pout3");
            }

            double startPower = double.Parse(StartBox.Text, provider);
            double endPower = double.Parse(StopBox.Text, provider);
            double step = double.Parse(StepBox.Text, provider);

            count = (int)((endPower - startPower) / step);

            ProgressLabel.Text = "0/" + count;
            Task.Factory.StartNew(() =>
            {
                IteratePower(filename, freq, freqBand, startPower, endPower, step, attenuation, gain);
            }).ContinueWith(_ => { IterationDone(); });
        }
        public void IteratePower(string filename, double freq, string freqBand, double startPower, double endPower, double step, 
                                            double attenuation, double gain)
        {
            int progress = 0;
            for (double power = startPower; power <= endPower; power+=step)
            {
                rfSource.SetCWPower(power-gain);

                // Read three harmonics of the output signal and the power supply readings
                double basePwr, secondPwr, thirdPwr, Vd, Id, Vg;
                (basePwr, secondPwr, thirdPwr, Vd, Id, Vg) = ReadData(freq, freqBand, attenuation);

                OutputData(filename, Vg, Vd, Id, power, basePwr+attenuation, secondPwr+attenuation, thirdPwr+attenuation);
                progress++;
                UpdateProgress(progress, count);

                rfSource.TurnOnOff(false);
                dcPowerSupply.TurnOnOff(1, false);
                dcPowerSupply.TurnOnOff(2, false);
            }
        }
        private (double, double, double, double, double, double) ReadData(double freq, string freqBand, double attenuation)
        {
            double basePwr = spectrumAnalyzer.MeasAtFrequency(freq, freqBand) + attenuation;
            double secondPwr = spectrumAnalyzer.MeasAtFrequency(2 * freq, freqBand) + attenuation;
            double thirdPwr = spectrumAnalyzer.MeasAtFrequency(3 * freq, freqBand) + attenuation;

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
            
            rfSource.TurnOnOff(false);
            dcPowerSupply.TurnOnOff(2, false);
            dcPowerSupply.TurnOnOff(1, false);
        }
    }

}
