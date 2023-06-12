using InstrumentDriverTest.InstrumentDrivers;
using InstrumentDriverTest.InstrumentDrivers.DCPowerSupply;
using InstrumentDriverTest.InstrumentDrivers.RFSource;
using InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer;
using MaxEfficiencySweep.Properties;
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

namespace MaxEfficiencySweep
{
    public partial class MaxEffSweepForm : Form
    {
        DCPowerSupply dcPowerSupply;
        RFSource rfSource;
        SpectrumAnalyzer spectrumAnalyzer;
        int count = 0;

        CancellationTokenSource tokenSource;
        CancellationToken token;

        NumberFormatInfo provider = new NumberFormatInfo();


        double Vg = 0;
        double Vd = 0;
        double Id = 0;
        double Pin = 0;
        double Pout = 0;
        double eff = 0;

        public MaxEffSweepForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        private void RefreshListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DCInstrumentList.Items.Clear();
                RFInstrumentList.Items.Clear();
                SAInstrumentList.Items.Clear();
                var deviceList = VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                    RFInstrumentList.Items.Add(device);
                    SAInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
                RFInstrumentList.SelectedIndex = 0;
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

        private void ApplyDCSrc1btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogText("DC power supply  not initialized!");
                return;
            }

            try
            {
                var voltageList = Src1VoltageBox.Text.Split(',');

                double voltage = double.Parse(voltageList[0], provider);
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
                var voltageList = Src2VoltageBox.Text.Split(',');

                double voltage = double.Parse(voltageList[0], provider);
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

        private void TurnOnDCSrcBtn_Click(object sender, EventArgs e)
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
                TurnOnDCSrcBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
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
            TurnOnDCSrcBtn.Enabled = enable;
        }

        private void ConnectRFBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RFInstrumentList.Text;
            try
            {
                rfSource = new E44xxB(gpibAddress);
                LogText("Registered device:");
                LogText(rfSource.idMsg);
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

        private void ApplyRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text, provider);
                rfSource.SetCWFrequency(freq, FreqBandBox.Text);


                var inputPowerList = PowerBox.Text.Split(',');

                double inputPower = double.Parse(inputPowerList[0], provider);
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
                TurnOnDCSrcBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        { // Setup
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
            if (PreampGainBox.Text != "")
            {
                gain = double.Parse(PreampGainBox.Text, provider);
            }

            if (CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }
            double freq = double.Parse(CWFreqBox.Text, provider);
            string freqBand = "GHz";


            var DC1VoltageList = Array.ConvertAll(Src1VoltageBox.Text.Split(','), double.Parse);
            var DC2VoltageList = Array.ConvertAll(Src2VoltageBox.Text.Split(','), double.Parse);
            var powerList = Array.ConvertAll(PowerBox.Text.Split(','), double.Parse);

            foreach (var dc2 in DC2VoltageList)
            {
                var filenameBase = Path.GetFileNameWithoutExtension(filename);
                var foldername = Path.GetDirectoryName(filename);
                var extension = Path.GetExtension(filename);
                var newFilename = String.Format("{0}\\{1}_{2}V{3}", foldername, filenameBase, dc2, extension);
                using (StreamWriter sw = File.CreateText(newFilename))
                {
                    sw.WriteLine("Vg Vd Id Pin Pout eff PAE");
                }
            }

            Vg = 0;
            Vd = 0;
            Id = 0;
            eff = 0;
            Pin = 0;
            Pout = 0;

            count = DC1VoltageList.Length*DC2VoltageList.Length*powerList.Length;

            ProgressLabel.Text = "0/" + count;
            rfSource.TurnOnOff(true);
            dcPowerSupply.TurnOnOff(1, true);
            dcPowerSupply.TurnOnOff(2, true);

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                Iterate(filename, freq, freqBand, powerList, attenuation, gain, DC1VoltageList, DC2VoltageList, token);
            }).ContinueWith(_ => { IterationDone(); });

        }

        public void Iterate(string filename, double freq, string freqBand, double[] powerList,
                                            double attenuation, double gain, double[] dc1VoltageList, double[] dc2VoltageList, CancellationToken ct)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            try
            {
                int progress = 0;
                foreach (var dc1 in dc1VoltageList)
                {
                    dcPowerSupply.SetVoltageLimit(1, dc1);
                    foreach (var power in powerList)
                    {
                        rfSource.SetCWPower(power - gain);

                        foreach (var dc2 in dc2VoltageList)
                        {
                            dcPowerSupply.SetVoltageLimit(2, dc2);
                            double basePwr, Vd, Id, Vg, eff;
                            (basePwr, Vd, Id, Vg, eff) = ReadData(freq, freqBand, attenuation);

                            double inPwrWatts = Math.Pow(10, (power - 30) / 10.0f);
                            double outPwrWatts = Math.Pow(10, (basePwr - 30) / 10.0f);
                            double PAE = (outPwrWatts - inPwrWatts) / (Vd * Id);


                            var filenameBase = Path.GetFileNameWithoutExtension(filename);
                            var foldername = Path.GetDirectoryName(filename);
                            var extension = Path.GetExtension(filename);
                            var newFilename = String.Format("{0}\\{1}_{2}V{3}", foldername, filenameBase, dc2, extension);
                            
                            OutputData(newFilename, Vg, Vd, Id, power, basePwr, eff, PAE);

                            if(eff > this.eff)
                            {
                                this.Vd = Vd;
                                this.Vg = Vg;
                                this.eff = eff;
                                this.Pin = power;
                                this.Id = Id;
                                this.Pout = basePwr;
                            }

                            progress++;
                            UpdateProgress(progress, count);

                            if (ct.IsCancellationRequested)
                            {
                                rfSource.TurnOnOff(false);
                                dcPowerSupply.TurnAllOnOff(false);
                                return;
                            }

                            SetText(BaseHarmBox, basePwr.ToString());
                            SetText(EffBox, eff.ToString());
                        }
                    }
                    // Read three harmonics of the output signal and the power supply readings

                }
            }
            catch (Exception ex)
            {
                LogText("Error has occured during execution: " + ex.Message);
            }
            finally
            {
                rfSource.TurnOnOff(false);
                dcPowerSupply.TurnOnOff(1, false);
                dcPowerSupply.TurnOnOff(2, false);
            }
        }


        private (double, double, double, double, double) ReadData(double freq, string freqBand, double attenuation)
        {
            double basePwr = spectrumAnalyzer.MeasAtFrequency(freq, freqBand) + attenuation;
            double basePwrWatts = Math.Pow(10, (basePwr-30)/10.0f);

            double Vg = dcPowerSupply.ReadVoltage(1);
            double Vd = dcPowerSupply.ReadVoltage(2);
            double Id = dcPowerSupply.ReadCurrent(2);
            double eff = basePwrWatts / (Vd * Id);

            return (basePwr, Vd, Id, Vg, eff);
        }


        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
            control.Text = text;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void OutputData(string filename, double vg, double vd, double id, double powerIn, double baseHarmPwr,
                                double efficiency, double PAE)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            vg, vd, id, powerIn, baseHarmPwr, efficiency, PAE));
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

            LogText(String.Format("Maximum efficiency is {0} which is obtained for Vg={1} V, Vd={2} V, Id={3} A, Pin={4} dBm and giving Pout={5} dBm", eff, -1*Vg, Vd, Id, Pin, Pout));
        }

        private void LogText(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogText), msg);
                return;
            }
            LogBox.AppendText(msg + Environment.NewLine);
            LogBox.ScrollToCaret();
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
