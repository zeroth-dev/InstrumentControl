using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.DCPowerSupply
{
    public abstract class DCPowerSupply : GeneralDevice
    {
        protected bool[] turnedOn { get; set; }

        protected DCPowerSupply() { }
        protected DCPowerSupply(string gpibAddress) : base(gpibAddress) { }

        /// <summary>
        /// Sets the maximum current for the specified source
        /// </summary>
        /// <param name="source">Source being modified</param>
        /// <param name="limit">Maximum current</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract void SetCurrentLimit(int source, double limit);

        /// <summary>
        /// Sets the maximum current for the specified source
        /// </summary>
        /// <param name="source">Source being modified</param>
        /// <param name="limit">Maximum current</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract void SetVoltageLimit(int source, double limit);

        /// <summary>
        /// Measures the current from the specified source
        /// </summary>
        /// <param name="source">Source being read from</param>
        /// <returns>Current output from the specified source</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// 
        public abstract double ReadCurrent(int source);
        /// <summary>
        /// Measures the voltage from the specified source
        /// </summary>
        /// <param name="source">1 or 2 describing the source</param>
        /// <returns>Voltage on the specified output</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public abstract double ReadVoltage(int source);

        /// <summary>
        /// Turns the power supply on or off
        /// </summary>
        /// <param name="source">Source being turned on or off</param>
        /// <param name="turnOn">true if turning the power supply ON and false otherwise</param>
        /// <exception cref="Exception"></exception>
        public abstract void TurnOnOff(int source, bool turnOn);

        /// <summary>
        /// Turns all the power supply sources on or off
        /// </summary>
        /// <param name="turnOn">true if turning the power supply ON and false otherwise</param>
        /// <exception cref="Exception"></exception>
        public abstract void TurnAllOnOff(bool turnOn);

        /// <summary>
        /// Checks if specified source is turned on or not
        /// </summary>
        /// <param name="source">Source being checked</param>
        /// <returns>true if the source is turned on and false otherwise</returns>
        public abstract bool IsTurnedOn(int source);

        /// <summary>
        /// For devices which cannot separate turning source on and off checks if the power is turned on
        /// </summary>
        /// <returns>true if the source is turned on and false otherwise</returns>
        public abstract bool IsTurnedOn();
    }
}
