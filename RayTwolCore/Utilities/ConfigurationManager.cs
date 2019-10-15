using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public class ConfigurationManager
    {
        private const string CONFIG_FILE = "RayTwol.ini";
        private const char CONFIG_FILE_SPLIT_CHAR = '\t';

        public string GetConfigFileValue(string key)
        {
            if (File.Exists(CONFIG_FILE))
            {
                using (StreamReader cfReader = new StreamReader(CONFIG_FILE))
                {
                    while (!cfReader.EndOfStream)
                    {
                        string line = cfReader.ReadLine();

                        if (line.Split(CONFIG_FILE_SPLIT_CHAR)[0] == $"{key}:")
                            return line.Split(CONFIG_FILE_SPLIT_CHAR)[2];//offset: 2 | CONFIG_FILE_SPLIT_CHAR appears twice in the line.
                    }

                    return null;//Returns null if nothing is found.
                }
            }
            else
                throw new FileNotFoundException($"Configuration file: '{CONFIG_FILE}' not found.");
        }
    }
}
