using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers
{
    public class Util
    {

        /// <summary>
        /// Utility function that returns a list of linear values increasing by 1 [min, max]
        /// </summary>
        /// <param name="min">Starting number in range</param>
        /// <param name="max">Ending number in range</param>
        /// <returns></returns>
        public static List<double> Range(double min, double max)
        {
            List<double> res = new List<double>();
            for (; min <= max; min++)
            {
                res.Add(min);
            }
            return res;
        }
    }
}
