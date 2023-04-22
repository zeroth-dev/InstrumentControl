using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InstrumentDriverTest.InstrumentDrivers.DCPowerSupply;
using Ivi.Visa;

namespace InstrumentDriverTest.InstrumentDrivers.DCPowerSupply
{
    public class E364xA_2 : DCPowerSupply
    {
        const int NoOfSources = 2;

        // Defaults are the lower of the two options for the device
        double[] maxCurrent = { 1.4, 1.4 };
        double[] minCurrent = { 0, 0 };
        double[] maxVoltage = { 35, 35 };
        double[] minVoltage = { 0, 0 };


        public E364xA_2(string gpibAddress) : base(gpibAddress)
        {
            // Check the maximum and minimum currents for each terminal
            VisaUtil.SendCmd(visa, "INST OUTP1");

            maxCurrent[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MAX");
            minCurrent[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");
            maxVoltage[0] = VisaUtil.SendReceiveFloatCmd(visa, "VOLT? MAX");
            minVoltage[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");

            VisaUtil.SendCmd(visa, "INST OUTP2");

            maxCurrent[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MAX");
            minCurrent[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");
            maxVoltage[1] = VisaUtil.SendReceiveFloatCmd(visa, "VOLT? MAX");
            minVoltage[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");

            turnedOn = new bool[] { false };
        }

        public override void SetCurrentLimit(int source, double limit)
        {
            if (source < NoOfSources || source > NoOfSources)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }
            if (limit > maxCurrent[source - 1] || limit < minCurrent[source - 1])
            {
                throw new ArgumentOutOfRangeException(String.Format("Specified current outside of range: {0}-{1}",
                                                                        minCurrent[source - 1], maxCurrent[source - 1]));
            }

            try
            {
                // Set the chosen source and set the current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("CURR {0}", limit.ToString(CultureInfo.InvariantCulture.NumberFormat));
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetVoltageLimit(int source, double limit)
        {
            if (source < NoOfSources || source > NoOfSources)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }
            if (limit > maxVoltage[source - 1] || limit < minVoltage[source - 1])
            {
                throw new ArgumentOutOfRangeException(String.Format("Specified current outside of range: {0}-{1}",
                                                                        minVoltage[source - 1], maxVoltage[source - 1]));
            }
            try
            {
                // Sets the chosen source and sets the voltage
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("VOLT {0}", limit.ToString(CultureInfo.InvariantCulture.NumberFormat));
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double ReadCurrent(int source)
        {
            if (source < NoOfSources || source > NoOfSources)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }

            try
            {
                // Select the specified source and measure its current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MEAS:CURR?");
                double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override double ReadVoltage(int source)
        {
            if (source < NoOfSources || source > NoOfSources)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }

            try
            {
                // Select the specified voltage and measure its current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MEAS:VOLT?");
                double voltage = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return voltage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override void TurnAllOnOff(bool turnOn)
        {
            try
            {
                var msg = string.Format("OUTP {0}", turnOn == true ? "ON" : "OFF");
                VisaUtil.SendCmd(visa, msg);
                this.turnedOn[0] = turnOn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void TurnOnOff(int source, bool turnOn)
        {
            // This device doesn't support turning on and off separate sources
            TurnAllOnOff(turnOn);
        }

        public override bool IsTurnedOn(int source)
        {
            // This device doesn't support turning on and off separate sources
            return IsTurnedOn();
        }

        public override bool IsTurnedOn()
        {
            return turnedOn[0];
        }
    }
}