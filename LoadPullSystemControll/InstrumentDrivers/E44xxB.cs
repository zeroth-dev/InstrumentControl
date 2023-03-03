using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPullSystemControl.Instruments
{
    internal class E44xxB
    {
        public string gpibAddress { get; }
        private bool initialized = false;
        public IMessageBasedSession visa = null;
        public string idMsg {get;}
        public bool turnedOn { get; set;}

        public E44xxB(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            try
            {
                (visa, idMsg) = VisaUtil.InitInstrument(gpibAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            initialized = true;
            turnedOn= false;
        }

        // Set CW frequency

        public void setCWFrequency(double frequency, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            var msg = String.Format("FREQ {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
            VisaUtil.SendCmd(visa, msg);
        }

        // Set CW power
        public void setCWPower(double power)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            var msg = String.Format("POW:AMPL {0}", power.ToString(CultureInfo.InvariantCulture.NumberFormat));
            VisaUtil.SendCmd(visa, msg);
        }

        // TODO Add an instrument defined sweep

        // Turn on or off
        public void turnOnOff(bool turnOn)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            try
            {
                string onMsg = turnOn ? "ON" : "OF";
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
