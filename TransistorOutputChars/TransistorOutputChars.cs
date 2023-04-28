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
using System.Windows.Forms.VisualStyles;
using TransistorOutputChars.Properties;

namespace TransistorOutputChars
{
    public partial class TransistorOutputChars : Form
    {
        DCPowerSupply dcPowerSupply;
        NumberFormatInfo provider = new NumberFormatInfo();
        public TransistorOutputChars()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
        }

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

        }


        private void RefreshListBtn_Click(object sender, EventArgs e)
        {

            try
            {
                DCInstrumentList.Items.Clear();
                var deviceList = VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
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
        {
            // Setup
            if (dcPowerSupply == null)
            {
                LogText("Please initialise all devices before starting the program");
            }


            // TODO: Create meaningful filename
            string filename = "Output.txt";
            if (FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("V1, I1, V2, I2");
            }


            double startV1 = double.Parse(Src1MinVBox.Text, provider);
            double stopV1 = double.Parse(Src1MaxVBox.Text, provider);
            double stepV1 = double.Parse(Src1StepVBox.Text, provider);

            double startV2 = double.Parse(Src2MinVBox.Text, provider);
            double stopV2 = double.Parse(Src2MaxVBox.Text, provider);
            double stepV2 = double.Parse(Src2StepVBox.Text, provider);

            double maxPower = double.Parse(MaxPowerBox.Text, provider);

            double curr1 = double.Parse(Src1CurrentBox.Text, provider);
            double curr2 = double.Parse(Src2CurrentBox.Text, provider);

            dcPowerSupply.SetCurrentLimit(1, curr1);
            dcPowerSupply.SetVoltageLimit(1, 0);

            dcPowerSupply.SetCurrentLimit(2, curr2);
            dcPowerSupply.SetVoltageLimit(2, 0);

            dcPowerSupply.TurnOnOff(1, true);
            dcPowerSupply.TurnOnOff(2, true);
            Task.Factory.StartNew(() =>
            {
                IterateDC(filename, startV1, stopV1, stepV1, startV2, stopV2, stepV2, maxPower);
            }).ContinueWith(_ => { IterationDone(); });
        }

        public void IterateDC(string filename, double startV1, double stopV1, double stepV1, double startV2, double stopV2, double stepV2, double maxPower)
        {
            for (double Vin = startV1; Vin <= stopV1+0.01; Vin += stepV1)
            {
                dcPowerSupply.SetVoltageLimit(1, Vin);

                for (double Vout = startV2; Vout <= stopV2+0.01; Vout += stepV2)
                {
                    dcPowerSupply.SetVoltageLimit(2, Vout);
                    Thread.Sleep(200);

                    double measV1 = dcPowerSupply.ReadVoltage(1);
                    double measI1 = dcPowerSupply.ReadCurrent(1);
                    double measV2 = dcPowerSupply.ReadVoltage(2);
                    double measI2 = dcPowerSupply.ReadCurrent(2);

                    double Ptot = measI1 * measV1 + measI2 * measV2;

                    OutputData(filename, measV1, measI1, measV2, measI2);

                    if (Math.Abs(Ptot - maxPower) < 0.2 || Ptot > maxPower)
                    {
                        dcPowerSupply.SetVoltageLimit(2, startV2);
                        break;
                    }
                }
            }
        }

        private void OutputData(string filename, double V1, double I1, double V2, double I2)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0} {1} {2} {3}",
                                            V1, I1, V2, I2));
            }
        }

        public void IterationDone()
        {
            LogText("Process Completed");

            dcPowerSupply.TurnOnOff(1, false);
            dcPowerSupply.TurnOnOff(2, false);
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

    }
}
