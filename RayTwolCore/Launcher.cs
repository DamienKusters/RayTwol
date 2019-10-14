using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public static class Launcher
    {
        public static bool Init()
        {
            Setup setup = new Setup();//TODO: Rename (Validator, Directorymanager....)

            //TODO: Either do Setup or start the main functionality, based on file integrity
            //Setup class checks for file integrity

            string gameDirectory = setup.GetGameDirectory();
            bool successfulSetup = false;

            do
            {
                ValidationError error = setup.ValidateGameDirectory(gameDirectory);

                //TODO: Read game directory files

            } while (!successfulSetup);//Reloop if setup isn't completed

            return true;
        }
    }
}
