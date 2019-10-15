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

                //TODO: Not quite SOLID, use classes with their own implementation on what to do if the error occurs.
                switch (status)
                {
                    case ValidationStatus.LevelsFolderMissing:
                        //TODO
                        break;
                    case ValidationStatus.LevelsDataFileMissing:
                        AskUserInput("LEVELS0.DAT not found",
                            "This is a retail install of Rayman 2 and requires LEVELS0.DAT, a 150 MB file included in the GOG version. Press OK to download and install the file.",
                            status);
                        break;
                    case ValidationStatus.LevelsDataFileCorrupt:
                        AskUserInput("LEVELS0.DAT corrupted",
                            "LEVELS0.DAT appears to be corrupted. Press OK to re-download.",
                            status);
                        break;
                    case ValidationStatus.RayTwolFolderMissing:
                        AskUserInput("Setup",
                            "Press OK to begin the first-time setup procedure. Once complete, RayTwol will open.",
                            status);
                        break;
                    case ValidationStatus.FolderSizeIntegrityError:
                        AskUserInput("Warning",
                            "First-time setup is not complete or setup-related files have been modified. If this error persists, press OK to re-initialise the setup.",
                            status);
                        break;
                    default:
                        break;
                }

            } while (status != ValidationStatus.Successful);//Reloop if setup isn't completed

            return true;
        }

        private void AskUserInput(string title, string message, ValidationStatus status)
        {
            bool userAccepted = _displayMessage(title, message);

            if (userAccepted)
            {
                //TODO: Move code & is inefficient
                //However, this is safe as the folder has already been checked if it exists
                if (status == ValidationStatus.LevelsDataFileCorrupt)
                    System.IO.File.Delete(_setup.GetGameDirectory() + "\\Data\\World\\Levels\\LEVELS0.DAT");
            }
            else
                Environment.Exit(0);
        }
    }
}
