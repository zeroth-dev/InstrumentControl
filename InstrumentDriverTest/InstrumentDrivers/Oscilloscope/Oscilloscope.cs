using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.Oscilloscope
{
    public abstract class Oscilloscope : GeneralDevice
    {

        protected Oscilloscope() { }
        protected Oscilloscope(string gpibAddress) : base(gpibAddress) { }

        public abstract (List<double>, List<double>) GetWaveform(int channel);

        public abstract List<double> GetFFT(int channel);

        public abstract double GetPeakToPeak(int channel);
        
        public abstract double GetPeakFFTAtFreq(int channel, double frequency, string freqBand);

    }
}
