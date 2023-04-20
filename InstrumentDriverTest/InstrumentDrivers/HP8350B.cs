using InstrumentDriverTest.Instruments;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace InstrumentDriverTest.InstrumentDrivers
{
    public class HP8350B
    {

        string gpibAddress { get; }
        private IMessageBasedSession visa = null;

        public HP8350B(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(this.gpibAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetFrequency(double frequency, string freqBand)
        {
            string band = "";
            if(freqBand.ToLower().Equals("mhz"))
            {
                band = "MZ";
            }
            else if (freqBand.ToLower().Equals("ghz"))
            {
                band = "GZ";
            }
            else
            {
                throw new Exception("Frequency band can only be GHz or MHz");
            }
            string cmd = String.Format("CW{0}{1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), band);
            try
            {
                VisaUtil.SendCmd(visa, cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SetRFPower(double power)
        {
            string cmd = String.Format("PL{0}", power.ToString(CultureInfo.InvariantCulture.NumberFormat));
            try
            {
                VisaUtil.SendCmd(visa, cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TurnRFOnOff(bool turnOn)
        {
            string cmd = String.Format("RF{0}", turnOn);
            try
            {
                VisaUtil.SendCmd(visa, cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
