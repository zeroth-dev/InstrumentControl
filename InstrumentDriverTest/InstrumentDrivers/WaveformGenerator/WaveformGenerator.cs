using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.WaveformGenerator
{
    public abstract class WaveformGenerator : GeneralDevice
    {
        public bool turnedOn { get; protected set; }
        protected WaveformGenerator(string gpibAddress) : base(gpibAddress)
        {
        }

        protected WaveformGenerator() { }

        public abstract void TurnOnOff(int source, bool turnOn);

        public abstract void SetSineWave(int source, double frequency, double amplitude, double offset, double phase);
    }
}
