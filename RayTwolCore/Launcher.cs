using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public class Launcher
    {
        private Action<string, string> DisplayMessage;

        public Launcher(Action<string, string> displayMessageAction)
        {
            DisplayMessage = displayMessageAction;
        }

        public bool Init()
        {
            Setup setup = new Setup();//TODO: Rename (Validator, Directorymanager....)

            //TODO: Either do Setup or start the main functionality, based on file integrity
            //Setup class checks for file integrity

            string gameDirectory = setup.GetGameDirectory();
            ValidationStatus status;

            do
            {
                status = setup.ValidateGameDirectory(gameDirectory);

                switch (status)
                {
                    case ValidationStatus.LevelsFolderMissing:
                        break;
                    case ValidationStatus.LevelsDataFileMissing:
                        ShowMessage("LEVELS0.DAT not found",
                            "This is a retail install of Rayman 2 and requires LEVELS0.DAT, a 150 MB file included in the GOG version. Press OK to download and install the file.");
                        break;
                    case ValidationStatus.LevelsDataFileCorrupt:
                        break;
                    case ValidationStatus.RayTwolFolderMissing:
                        break;
                    case ValidationStatus.FolderSizeIntegrityError:
                        break;
                    default:
                        break;
                }

                //TODO: Read game directory files

            } while (status != ValidationStatus.Successful);//Reloop if setup isn't completed

            return true;
        }

        private void ShowMessage(string title, string message)
        {
            //TODO: Call message pop-up delegate injected through the Init method
            DisplayMessage(title, message);//TODO change to predicate, as it returns a bool
            /*
            var warn = new Warning("LEVELS0.DAT not found", "This is a retail install of Rayman 2 and requires LEVELS0.DAT, a 150 MB file included in the GOG version. Press OK to download and install the file.").ShowDialog();
            if (warn.Value)
            {
                var dl = new Downloader();
                dl.ShowDialog();
                if ((bool)!dl.DialogResult)
                    Environment.Exit(0);
            }
            else
                Environment.Exit(0);
                */
        }
    }
}
