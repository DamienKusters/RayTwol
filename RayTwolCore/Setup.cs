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

        public void A()
        {
            throw new NotImplementedException();
            /*
            //This region is responsible for getting the file path of Rayman 2
            bool validSetup = false;

            while (!validSetup)
            {
                if (File.Exists(CONFIG_FILE))
                {
                    using (StreamReader cfReader = new StreamReader(CONFIG_FILE))
                    {
                        while (!cfReader.EndOfStream)
                        {
                            string line = cfReader.ReadLine();
                            switch (line.Split(CONFIG_FILE_SPLIT_CHAR)[0])
                            {
                                case "dir:":
                                    cf_gameDir = line.Split(CONFIG_FILE_SPLIT_CHAR)[2];
                                    break;
                            }
                        }
                    }
                }

                if (cf_gameDir == null)
                    InvalidDir();//Shows UI error, asks the user for the new path, and tries again.
                else
                {
                    //Final check if the level folder actually exist (Doesn't check for integrity)
                    if (Directory.Exists(cf_gameDir + "\\Data\\World\\Levels"))
                        validSetup = true;
                    else//If not, ask again.
                        InvalidDir();
                }
            }

            //Get all folders (level folders) in the Levels directory and check if from that level the .sna is included (possibly geomitry data)
            foreach (DirectoryInfo levelDir in new DirectoryInfo(cf_gameDir + "\\Data\\World\\Levels").GetDirectories("*", SearchOption.AllDirectories))
                if (File.Exists(levelDir.FullName + "\\" + levelDir.Name + ".sna"))
                    levelFiles.Add(new FileInfo(levelDir.FullName + "\\" + levelDir.Name + ".sna"));


            Setup.SetupChecks();*/
        }
    }
}
