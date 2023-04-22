using InstrumentDriverTest.InstrumentDrivers.DCPowerSupply;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.RFSource
{
    public class E44xxB : RFSource
    {

        public E44xxB(string gpibAddress) : base(gpibAddress)
        {
            turnedOn = false;
        }

        public override void SetCWFrequency(double frequency, string freqBand)
        {
            try
            {
                var msg = String.Format("FREQ {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(base.visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetCWPower(double power)
        {
            try
            {
                var msg = String.Format("POW:AMPL {0}", power.ToString(CultureInfo.InvariantCulture.NumberFormat));
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void TurnOnOff(bool turnOn)
        {
            try
            {
                string onMsg = turnOn ? "ON" : "OFF";
                var msg = String.Format("OUTP:STAT {0}", onMsg);
                VisaUtil.SendCmd(visa, msg);
                turnedOn = turnOn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

