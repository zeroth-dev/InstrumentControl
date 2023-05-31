using InstrumentDriverTest.InstrumentDrivers;
using InstrumentDriverTest.InstrumentDrivers.DCPowerSupply;
using InstrumentDriverTest.InstrumentDrivers.Oscilloscope;
using InstrumentDriverTest.InstrumentDrivers.RFSource;
using InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer;
using InstrumentDriverTest.InstrumentDrivers.WaveformGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PowerDetectorTest
{
    public partial class PowerDetectorTestForm : Form
    {
        WaveformGenerator waveformGenerator;
        RFSource rfSource;
        Oscilloscope oscilloscope;
        int progress = 0;
        int count = 0;

        NumberFormatInfo provider = new NumberFormatInfo(); 
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public PowerDetectorTestForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
        }

        private void ConnectWGBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = WGInstrumentList.Text;
            try
            {
                waveformGenerator = new WG33600A(gpibAddress);
                LogText("Registered device:");
                LogText(waveformGenerator.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }


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


        private void ApplyRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text, provider);
                rfSource.SetCWFrequency(freq, "GHz");

                double inputPower = double.Parse(StartBox.Text, provider);
                rfSource.SetCWPower(inputPower);
                LogText(String.Format("Set RF frequency {0} GHz and power {2} dBm",
                                        freq.ToString(provider), (inputPower).ToString(provider)));
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
                TurnOnRFBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void ConnectOscBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = OscInstrumentList.Text;
            try
            {
                oscilloscope = new MSO7034B(gpibAddress);
                LogText("Registered device:");
                LogText(oscilloscope.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

        }

        private void ApplyWGbtn_Click(object sender, EventArgs e)
        {
            try
            {
                double wgFrequency = double.Parse(StartFreqBox.Text, provider);
                double voltage = double.Parse(VoltageBox.Text, provider);
                waveformGenerator.SetSineWave(1, wgFrequency * 1e6, voltage, 0, 0);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

        }

        private void TurnOnWGBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool turnOn = !waveformGenerator.turnedOn;
                waveformGenerator.TurnOnOff(1, turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnWGBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");

            }
            catch(Exception ex)
            {
                LogText(ex.Message);
                return;
            }
        }

        private void TurnAMOnOffBtn_Click(object sender, EventArgs e)
        {

            try
            {
                bool turnOn = !rfSource.AMWBTurnedOn;
                rfSource.TurnAMWBOnOff(turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnWGBtn.Text = String.Format("Turn AM {0}", turnOn ? "off" : "on");

            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
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

        private void StartBtn_Click(object sender, EventArgs e)
        { // Setup
            if (waveformGenerator == null || oscilloscope == null || rfSource == null)
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
                LogText("Please input the wanted carrier frequency");
            }

            double freqStart = 0;
            if (StartFreqBox.Text != "")
            {
                freqStart = double.Parse(StartFreqBox.Text, provider);
            }

            double freqStop = freqStart;
            if (StopFreqBox.Text != "")
            {
                freqStop = double.Parse(StopFreqBox.Text, provider);
            }

            double freqStep = freqStart;
            if (StepFreqBox.Text != "")
            {
                freqStep = double.Parse(StepFreqBox.Text, provider);
            }

            if (CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }
            double freq = double.Parse(CWFreqBox.Text, provider);
            rfSource.SetCWFrequency(freq, "GHz");

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("VppIn freq Pcarr VppOut, FFTPeak");
            }

            double startPower = double.Parse(StartBox.Text, provider);
            double endPower = double.Parse(StopBox.Text, provider);
            double step = double.Parse(StepBox.Text, provider);

            double Vpp = double.Parse(VoltageBox.Text, provider);

            var countPower = (int)((endPower - startPower) / step) + 1;
            var countFreq = (int)((freqStop - freqStart) / freqStep) + 1;
            count = countPower * countFreq;
            progress = 0;
            ProgressLabel.Text = "0/" + count;
            rfSource.TurnOnOff(true);
            waveformGenerator.TurnOnOff(1, true);
            rfSource.TurnAMWBOnOff(true);


            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                Iterate(filename, freqStart, freqStop, freqStep, Vpp, startPower, endPower, step, token);
            }).ContinueWith(_ => { IterationDone(); });

        }

        private void Iterate(string filename, double freqStart, double freqStop, double freqStep, double Vpp, double startPower, double stopPower, double stepPower, CancellationToken ct)
        {
            for(double power = startPower; power <=stopPower; power+=stepPower)
            {
                rfSource.SetCWPower(power);
                for (double freq = freqStart; freq<=freqStop; freq+=freqStep)
                {
                    waveformGenerator.SetSineWave(1, freq*1E6, Vpp, 0, 0);
                    Thread.Sleep(500);
                    var (Vppeak, time, VScope, peakFFT, frequency, FFT) = ReadData();
                    var filenameBase = Path.GetFileNameWithoutExtension(filename);
                    var foldername=Path.GetDirectoryName(filename);
                    var extension = Path.GetExtension(filename);
                    var scopeFilename = String.Format("{0}\\{1}_scope_freq_{2}MHz_P_{3}dBm{4}",foldername, filenameBase, freq, power, extension);
                    var FFTFilename = String.Format("{0}\\{1}_FFT_freq_{2}MHz_P_{3}dBm{4}",foldername, filenameBase, freq, power, extension);

                    OutputData(filename, Vpp, freq, power, Vppeak, peakFFT);
                    OutputScope(scopeFilename, time, VScope);
                    OutputFFT(FFTFilename, frequency, FFT);

                    if (ct.IsCancellationRequested)
                    {
                        rfSource.TurnOnOff(false);
                        waveformGenerator.TurnOnOff(1, false);
                        return;
                    }

                    progress++;
                    UpdateProgress(progress, count);

                }
            }
        }

        private (double, List<double>, List<double>, double, List<double>, List<double>) ReadData()
        {
            double Vpp = oscilloscope.GetPeakToPeak(1);
            (List<double> time, List<double> VScope) = oscilloscope.GetWaveform(1, Oscilloscope.AcquisitionType.NORMAL);

            double peakFFT = oscilloscope.GetPeakFFT(1);
            (List<double> frequency, List<double> FFT) = oscilloscope.GetFFT(1, Oscilloscope.AcquisitionType.NORMAL);

            return(Vpp, time, VScope,  peakFFT, frequency, FFT);

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void BrowseImgPathBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "De-embedding data";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImgPathBox.Text = saveFileDialog.FileName;
                }
            }

        }

        private void SaveImgBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (ImgPathBox.Text == "")
                {
                    LogText("Please enter path for the image");
                    return;
                }
                var img = oscilloscope.GetImage();
                File.WriteAllBytes(ImgPathBox.Text, img);
            }
            catch(Exception ex)
            {
                LogText(ex.Message);
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

        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
            control.Text = text;
        }

        private void OutputData(string filename, double VppIn, double freq, double rfPower, double VppOut, double FFTPeak)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0} {1} {2} {3} {4}", VppIn, freq, rfPower, VppOut, FFTPeak));
            }
        }

        private void OutputScope(string filename, List<double> time, List<double> scope)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                for(int i = 0; i < time.Count; i++)
                {
                    sw.WriteLine(String.Format("{0} {1}", time[i], scope[i]));
                }
            }
        }

        private void OutputFFT(string filename, List<double> frequency, List<double> FFT)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                for (int i = 0; i < frequency.Count; i++)
                {
                    sw.WriteLine(String.Format("{0} {1}", frequency[i], FFT[i]));
                }
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
            rfSource.TurnAMWBOnOff(false);
            waveformGenerator.TurnOnOff(1, false);
        }

        private void RefreshListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                WGInstrumentList.Items.Clear();
                RFInstrumentList.Items.Clear();
                OscInstrumentList.Items.Clear();
                var deviceList = VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    WGInstrumentList.Items.Add(device);
                    RFInstrumentList.Items.Add(device);
                    OscInstrumentList.Items.Add(device);
                }
                WGInstrumentList.SelectedIndex = 0;
                RFInstrumentList.SelectedIndex = 0;
                OscInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

    }


}
