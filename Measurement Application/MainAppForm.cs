using LoadPullSystemControl;
using PAPowerSweep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tone_2Test;
using TransistorOutputChars;

namespace Measurement_Application
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitAppList();
        }

        private void MainStartBtn_Click(object sender, EventArgs e)
        {
            switch(AppListBox.Text)
            {
                case "Load pull app":
                    LoadPullForm app = new LoadPullForm();
                    app.ShowDialog();
                    break;
                case "Power sweep app":
                    PowerSweepForm PowerSweepApp = new PowerSweepForm();
                    PowerSweepApp.ShowDialog();
                    break;
                case "2 Tone test app":
                    Tone_2Test_Form tone_2Test = new Tone_2Test_Form();
                    tone_2Test.ShowDialog();
                    break;
                case "DC Characteristics":
                    TransistorOutputCharsForm transistorOutputCharsForm = new TransistorOutputCharsForm();
                    transistorOutputCharsForm.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void InitAppList()
        {
            AppListBox.Items.Add("Load pull app");
            AppListBox.Items.Add("Power sweep app");
            AppListBox.Items.Add("2 Tone test app");
            AppListBox.Items.Add("DC Characteristics");
        }
    }
}
