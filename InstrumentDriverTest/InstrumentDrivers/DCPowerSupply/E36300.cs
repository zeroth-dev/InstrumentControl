
using InstrumentDriverTest.InstrumentDrivers;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.DCPowerSupply
{
    public class E36300 : DCPowerSupply
    {

        public E36300(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            try
            {
                (visa, idMsg) = VisaUtil.InitInstrument(this.gpibAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            turnedOn = new bool[3];
            turnedOn[0] = false;
            turnedOn[1] = false;
            turnedOn[2] = false;
        }

        public override void SetCurrentLimit(int source, double limit)
        {
            try
            {
                string msg = String.Format("CURR {0}, (@{1})", limit.ToString(CultureInfo.InvariantCulture.NumberFormat), source);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetVoltageLimit(int source, double limit)
        {
            try
            {
                string msg = String.Format("VOLT {0}, (@{1})", limit.ToString(CultureInfo.InvariantCulture.NumberFormat), source);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double ReadCurrent(int source)
        {
            try
            {
                string msg = String.Format("MEAS:CURR? (@{0})", source);
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
            try
            {
                string msg = String.Format("MEAS:VOLT? (@{0})", source);
                double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void TurnOnOff(int source, bool turnOn)
        {
            try
            {
                var msg = string.Format("OUTP {0}, (@{1})", turnOn == true ? "ON" : "OFF", source);
                VisaUtil.SendCmd(visa, msg);
                turnedOn[source - 1] = turnOn;
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
                TurnOnOff(1, turnOn);
                TurnOnOff(2, turnOn);
                TurnOnOff(3, turnOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool IsTurnedOn(int source)
        {
            return turnedOn[source - 1];
        }

        public override bool IsTurnedOn()
        {
            throw new NotImplementedException("Not supported");
        }
    }
}
