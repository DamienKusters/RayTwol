using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public class Setup
    {
        private const string CONFIG_FILE = "RayTwol.ini";
        private const char CONFIG_FILE_SPLIT_CHAR = '\t';

        private string GetConfigFileValue(string key)
        {
            if (File.Exists(CONFIG_FILE))
            {
                using (StreamReader cfReader = new StreamReader(CONFIG_FILE))
                {
                    while (!cfReader.EndOfStream)
                    {
                        string line = cfReader.ReadLine();

                        if(line.Split(CONFIG_FILE_SPLIT_CHAR)[0] == $"{key}:")
                            return line.Split(CONFIG_FILE_SPLIT_CHAR)[2];//offset: 2 | CONFIG_FILE_SPLIT_CHAR appears twice in the line.
                    }

                    return null;//Returns null if nothing is found.
                }
            }
            else
                throw new FileNotFoundException($"Configuration file: '{CONFIG_FILE}' not found.");
        }

        /// <summary>
        /// Checks the game file integrity of the directory.
        /// </summary>
        /// <param name="gameDirectory"></param>
        /// <returns></returns>
        public bool ValidateGameDirectory(string gameDirectory)
        {
            if (String.IsNullOrEmpty(gameDirectory))
                return false;
            else
                return Directory.Exists(gameDirectory + @"\Data\World\Levels");
        }

        private List<FileInfo> ReadGameDirectoryLevelFiles(string levelsDirectory)
        {
            List<FileInfo> output = new List<FileInfo>();

            foreach (DirectoryInfo levelDir in new DirectoryInfo(levelsDirectory).GetDirectories("*", SearchOption.AllDirectories))
            {
                if (File.Exists(levelDir.FullName + "\\" + levelDir.Name + ".sna"))
                    output.Add(new FileInfo(levelDir.FullName + "\\" + levelDir.Name + ".sna"));
            }

            return null;
        }

        public string GetGameDirectory()
        {
            try
            {
                return GetConfigFileValue("dir");
            }
            catch (FileNotFoundException ex)
            {
                //TODO: Notify user / Or start setup
                throw;
            }
        }
    }
}
