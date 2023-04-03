using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LoadPullSystemControl.Util
{
    public class Utils
    {
        public enum FrequencyBand : Int64
        {
            NONE = 0,
            Hz = 1,
            kHz = 1000,
            Mhz = 1000000,
            Ghz = 1000000000
        }

        public static List<Complex> GetSParamsFromFile(string path, double freq, string wantedBand)
        {
            FrequencyBand band = GetFrequencyBand(wantedBand);
            if(!File.Exists(path))
            {
                throw new FileNotFoundException(String.Format("File at {0} does not exist", path));
            }

            FrequencyBand fileFreqBand = FrequencyBand.NONE;
            var lines = File.ReadLines(path);
            var previousLine = "";
            foreach(var line in lines )
            {
                if (fileFreqBand == FrequencyBand.NONE)
                {
                    if (line[0].Equals('!'))
                    {
                        previousLine = line;
                        continue;
                    }
                    // Standard s2p file has a line with measurement properties that starts with '#'
                    if (line[0].Equals('#'))
                    {
                        // Set the frequency band of the s-parameter file
                        // Assumes a format similar to:
                        // # GHZ S DB R 50
                        var parameters = line.Split(' ');
                        fileFreqBand = GetFrequencyBand(parameters[0]);
                        continue;
                    }
                    // In case of a custom file, properties may not be present with a "#" 
                    // but with a custom line. Check the line for the frequency band
                    if (!line[0].Equals('!') && !line[0].Equals('#'))
                    {
                        var lowerCaseLine = previousLine.ToLower();
                        if (lowerCaseLine.Contains("ghz"))
                        {
                            fileFreqBand = FrequencyBand.Ghz;
                        }
                        else if (lowerCaseLine.Contains("mhz"))
                        {
                            fileFreqBand = FrequencyBand.Mhz;
                        }
                        else if (lowerCaseLine.Contains("khz"))
                        {
                            fileFreqBand = FrequencyBand.kHz;
                        }
                        else if (lowerCaseLine.Contains("hz"))
                        {
                            fileFreqBand = FrequencyBand.Hz;
                        }
                        else
                        {
                            fileFreqBand= FrequencyBand.NONE;
                        }
                    }
                }
                if(fileFreqBand != FrequencyBand.NONE)
                {
                    var values = Array.ConvertAll(line.Split(' '), Double.Parse);
                    var frequency = values[0];
                    double convertedFreq = frequency * ((Int64)fileFreqBand / (Int64)band);
                    if(convertedFreq == freq)
                    {
                        List<Complex> sParams = new List<Complex>();
                        sParams.Add(new Complex(values[1], values[2]));
                        sParams.Add(new Complex(values[3], values[4]));
                        sParams.Add(new Complex(values[5], values[6]));
                        sParams.Add(new Complex(values[7], values[8]));
                        return sParams;
                    }
                }
            }
            // If we got here the frequency does not exist
            throw new Exception("Wanted frequency does not exist in the s-parameter file provided");
        }

        public static FrequencyBand GetFrequencyBand(string band) 
        {
            switch (band.ToLower())
            {

                case "ghz":
                    return FrequencyBand.Ghz;
                case "mhz":
                    return FrequencyBand.Mhz;
                case "khz":
                    return FrequencyBand.kHz;
                case "hz":
                    return FrequencyBand.Hz;
                default:
                    return FrequencyBand.NONE;  
            }

        }
    }
}
