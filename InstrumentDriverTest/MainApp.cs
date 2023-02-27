using InstrumentDriverTest.TestForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentDriverTest
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TestOscBtn_Click(object sender, EventArgs e)
        {

        }

        private void TestSpectAnBtn_Click(object sender, EventArgs e)
        {

        }

        private void TestDCBtn_Click(object sender, EventArgs e)
        {
            var dcTest = new DCTestForm();
            dcTest.ShowDialog();
        }

        private void TestVNABtn_Click(object sender, EventArgs e)
        {

        }

        private void GenBtn_Click(object sender, EventArgs e)
        {
            var general = new GeneralComms();
            general.ShowDialog();
        }

        private void TestRFSrcBtn_Click(object sender, EventArgs e)
        {
            var RFTest = new RFSrcTest();
            RFTest.ShowDialog();
        }
    }
}
