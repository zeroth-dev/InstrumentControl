using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer
{
    public abstract class SpectrumAnalyzer : GeneralDevice
    {
        protected SpectrumAnalyzer(string gpibAddress) : base(gpibAddress) { }

        protected SpectrumAnalyzer() { }

        /// <summary>
        /// Sets the central frequency and span for the spectral analyzer
        /// </summary>
        /// <param name="frequency">Central frequency for the SA</param>
        /// <param name="span">Span of the display (same frequency band as central frequency) </param>
        /// <param name="freqBand">Frequency band for the specified frequency</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract void SetCentralFrequency(double frequency, double span, string freqBand);

        /// <summary>
        /// Set the starting and final frequency for the measurement
        /// </summary>
        /// <param name="startFreq">Starting frequency</param>
        /// <param name="stopFreq">Final frequency</param>
        /// <param name="freqBandStart">Frequency band of the starting frequency</param>
        /// <param name="freqBandStop">Frequency band of the final frequency</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract void SetStartStopFrequency(int startFreq, int stopFreq, string freqBandStart, string freqBandStop);

        /// <summary>
        /// Measures the power at the central frequency from the SA
        /// </summary>
        /// <returns>Measured power in dBm</returns>
        /// <exception cref="Exception"></exception>
        public abstract double MeasCentralPower();

        /// <summary>
        /// Measures the peak power around 10% band from the specified central frequency
        /// </summary>
        /// <param name="frequency">Specified central frequency</param>
        /// <param name="freqBand">Frequency band for the specified frequency</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract double MeasPeak(double frequency, string freqBand);

    }
}
