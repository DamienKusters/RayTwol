using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public class Launcher
    {
        private Setup _setup;
        private Func<string, string, bool> _displayMessage;

        public Launcher(Func<string, string, bool> displayMessageDelegate)
        {
            _setup = new Setup();
            _displayMessage = displayMessageDelegate;
        }

        public bool Init()
        {
            string gameDirectory = _setup.GetGameDirectory();
            ValidationStatus status;

            do
            {
                status = _setup.ValidateGameDirectory(gameDirectory);

                AskUserInput(status);

            } while (status.IsError == false);//Reloop if setup isn't completed

            return true;
        }

        private void AskUserInput(ValidationStatus status)
        {
            bool userAccepted = _displayMessage(status.Title, status.Description);

            if (userAccepted)
            {
                //TODO: Move code & is inefficient
                //However, this is safe as the folder has already been checked if it exists
                /*
                if (status == ValidationStatus.LevelsDataFileCorrupt)
                    System.IO.File.Delete(_setup.GetGameDirectory() + "\\Data\\World\\Levels\\LEVELS0.DAT");*/
            }
            else
                Environment.Exit(0);
        }
    }
}
