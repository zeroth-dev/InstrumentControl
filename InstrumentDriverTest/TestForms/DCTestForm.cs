using InstrumentDriverTest.Instruments;
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
    public partial class DCTestForm : Form
    {
        private E364xA dcPowerSupply;


        NumberFormatInfo provider = new NumberFormatInfo();
        public DCTestForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InstrumentList.Items.Clear();
                var deviceList = Instruments.VisaUtil.GetConnectedDeviceList();
                foreach(var device in deviceList)
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
                dcPowerSupply = new E364xA(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableBtns(true);
        }

        private void EnableBtns(bool enable)
        {
            ApplySrc1btn.Enabled = enable;
            ApplySrc2Btn.Enabled = enable;
            TurnOffSrc1Btn.Enabled = enable;
            TurnOffSrc2Btn.Enabled = enable;
            TurnOnSrc1Btn.Enabled = enable;
            TurnOnSrc2Btn.Enabled = enable;
        }

        private void ApplySrc1btn_Click(object sender, EventArgs e)
        {
            if(dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                double voltage = double.Parse(Src1VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(1, voltage);
                double current = double.Parse(Src1CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(1, current);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

        }

        private void TurnOnSrc1Btn_Click(object sender, EventArgs e)
        {

            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                dcPowerSupply.TurnOnOff(true);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOffSrc1Btn_Click(object sender, EventArgs e)
        {

            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }
            try
            {
                dcPowerSupply.TurnOnOff(false);
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void ApplySrc2Btn_Click(object sender, EventArgs e)
        {

            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                double voltage = double.Parse(Src2VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(2, voltage);
                double current = double.Parse(Src2CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(2, current);
            }
            catch(Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }
        }

        private void TurnOnSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                dcPowerSupply.TurnOnOff(true);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void TurnOffSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                dcPowerSupply.TurnOnOff(false);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }

        }

        private void SendCmdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var output = Instruments.VisaUtil.SendReceiveStringCmd(dcPowerSupply.visa, CmdBox.Text);
                LogBox.AppendText(output + Environment.NewLine);
            } 
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }
    }
}
