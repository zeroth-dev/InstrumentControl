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

        public enum AcquisitionType
        {
            NORMAL = 0,
            AVERAGE = 1,
            HRES = 2,
            PEAK = 3,
            COUNT = 4,
        }

        public abstract (List<double>, List<double>) GetWaveform(int channel, AcquisitionType aquisitionType, UInt16 count = 0);

        public abstract List<double> GetFFT(int channel);

        public abstract double GetPeakToPeak(int channel);
        
        public abstract double GetPeakFFTAtFreq(int channel, double frequency, string freqBand);

        public abstract List<double> GetPreamble();

        protected string GetNameFromAcquisitionType(AcquisitionType acquisitionType)
        {
            switch (acquisitionType)
            {
                case AcquisitionType.NORMAL:
                    return "NORMAL";
                case AcquisitionType.AVERAGE:
                    return "AVERAGE";
                case AcquisitionType.HRES:
                    return "HRES";
                case AcquisitionType.PEAK:
                    return "PEAK";
                default:
                    return "";
            }
        }

        public abstract void SaveImage(string filename);
    }
}
