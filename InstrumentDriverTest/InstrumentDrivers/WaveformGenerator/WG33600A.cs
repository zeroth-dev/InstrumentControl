using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.WaveformGenerator
{
    public class WG33600A : WaveformGenerator
    {
        public WG33600A(string gpibAddress) : base(gpibAddress)
        {
        }

        public override void SetSineWave(int source, double frequency, double amplitude, double offset, double phase)
        {

            try
            {
                string msg = string.Format("APPLY:SIN {0},{1} VPP,{2}", frequency.ToString("0.000E0", CultureInfo.InvariantCulture.NumberFormat), amplitude.ToString(CultureInfo.InvariantCulture.NumberFormat), offset.ToString());

                VisaUtil.SendCmd(visa, msg);

                msg = string.Format("SOURCE{0}:PHASE {1}", source.ToString(), phase.ToString());
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void TurnOnOff(int source, bool turnOn)
        {
            try
            {
                turnedOn = turnOn;
                string msg = string.Format("OUTPUT {0}", source.ToString(), turnOn==true ? "1" : "0");
                VisaUtil.SendCmd(visa, msg);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
