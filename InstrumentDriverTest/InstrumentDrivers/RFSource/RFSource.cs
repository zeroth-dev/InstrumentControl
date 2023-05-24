using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.RFSource
{
    public abstract class RFSource : GeneralDevice
    {
        public bool turnedOn { get; protected set; }
        public bool AMWBTurnedOn { get; protected set; }
        protected RFSource(string gpibAddress) : base(gpibAddress)
        {
        }

        protected RFSource() { }

        /// <summary>
        /// Sets the continuous wave frequency on the RF source
        /// </summary>
        /// <param name="frequency">Wanted frequency</param>
        /// <param name="freqBand">Specified frequency band {Hz|kHz|MHz|GHz}</param>
        /// <exception cref="Exception"></exception>
        public abstract void SetCWFrequency(double frequency, string freqBand);

        /// <summary>
        /// Sets the wanted continuous wave power in dBm on the RF source
        /// </summary>
        /// <param name="power">Wanted power in dBm</param>
        /// <exception cref="Exception"></exception>
        public abstract void SetCWPower(double power);

        /// <summary>
        /// Turns the RF source on or off
        /// </summary>
        /// <param name="turnOn">true if turning ON the RF source, false otherwise</param>
        /// <exception cref="Exception"></exception>
        public abstract void TurnOnOff(bool turnOn);

        public abstract void TurnAMWBOnOff(bool WBOn);

        public abstract void TurnAMOnOff(int AMSource, bool turnOn);
    }
}
