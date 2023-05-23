using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.Oscilloscope
{
    public class Oscilloscope : GeneralDevice
    {

        protected Oscilloscope() { }
        protected Oscilloscope(string gpibAddress) : base(gpibAddress) { }
    }
}
