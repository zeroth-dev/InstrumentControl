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
    public partial class GeneralComms : Form
    {
        public GeneralComms()
        {
            InitializeComponent();
        }

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

        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var gpibAddress = InstrumentList.Text;
                var cmd = CmdBox.Text;
                var output = InstrumentDrivers.VisaUtil.SendReceiveStringCmd(gpibAddress, cmd);
                LogBox.AppendText(output + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }
    }
}
