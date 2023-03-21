using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.Instruments
{
    public class E44xxB
    {
        public string gpibAddress { get; }
        private bool initialized = false;
        public IMessageBasedSession visa = null;
        public string idMsg { get; }
        public bool turnedOn { get; set; }

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
            turnedOn = false;
        }

        /// <summary>
        /// Sets the continuous wave frequency on the RF source
        /// </summary>
        /// <param name="frequency">Wanted frequency</param>
        /// <param name="freqBand">Specified frequency band {Hz|kHz|MHz|GHz}</param>
        /// <exception cref="Exception"></exception>
        public void SetCWFrequency(double frequency, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            try
            {
                var msg = String.Format("FREQ {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the wanted continuous wave power in dBm on the RF source
        /// </summary>
        /// <param name="power">Wanted power in dBm</param>
        /// <exception cref="Exception"></exception>
        public void SetCWPower(double power)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

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

        /// <summary>
        /// Turns the RF source on or off
        /// </summary>
        /// <param name="turnOn">true if turning ON the RF source, false otherwise</param>
        /// <exception cref="Exception"></exception>
        public void TurnOnOff(bool turnOn)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
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

