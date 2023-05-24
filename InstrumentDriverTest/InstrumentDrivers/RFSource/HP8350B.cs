using InstrumentDriverTest.InstrumentDrivers;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.RFSource
{
    public class HP8350B : RFSource
    {

        public HP8350B(string gpibAddress) : base()
        {
            base.gpibAddress = gpibAddress;
            try
            {
                (base.visa, _) = VisaUtil.InitInstrument(this.gpibAddress, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            base.turnedOn = false;
        }


        public override void SetCWFrequency(double frequency, string freqBand)
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

        public override void SetCWPower(double power)
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

        public override void TurnAMOnOff(int AMSource, bool turnOn)
        {
            throw new NotImplementedException();
        }

        public override void TurnAMWBOnOff(bool WBOn)
        {
            throw new NotImplementedException();
        }

        public override void TurnOnOff(bool turnOn)
        {
            string cmd = String.Format("RF{0}", turnOn);
            try
            {
                VisaUtil.SendCmd(visa, cmd);
                turnedOn = turnOn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
