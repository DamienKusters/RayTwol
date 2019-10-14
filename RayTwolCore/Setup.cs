using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public enum ValidationError
    {
        LevelsFolderMissing,

        LevelsDataFileMissing,
        LevelsDataFileCorrupt,

        RayTwolFolderMissing,

        FolderSizeIntegrityError,

        Successful
    }

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
        /// <returns>enum ValidationError</returns>
        public ValidationError ValidateGameDirectory(string gameDirectory)
        {
            if (!Directory.Exists(gameDirectory + @"\Data\World\Levels"))
                return ValidationError.LevelsFolderMissing;

            return ValidateFileIntegrity(gameDirectory);
        }

        private ValidationError ValidateFileIntegrity(string levelsDirectory)
        {
            throw new NotImplementedException();
            /*
            string levels0File = levelsDirectory + "\\LEVELS0.DAT";
            string raytwolFolder = levelsDirectory + "\\_raytwol";

            // Check for LEVELS0.DAT
            if (!File.Exists(levels0File))
            {
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
            }
            else if (new FileInfo(levels0File).Length != INST_LEVELS0_SIZE)
            {
                var warn = new Warning("LEVELS0.DAT corrupted", "LEVELS0.DAT appears to be corrupted. Press OK to re-download.").ShowDialog();
                if (warn.Value)
                {
                    File.Delete(Editor.cf_gameDir + "\\LEVELS0.DAT");
                    var dl = new Downloader();
                    dl.ShowDialog();
                    if ((bool)!dl.DialogResult)
                        Environment.Exit(0);
                }
                else
                    Environment.Exit(0);
            }
            /*
            // Check if RayTwol has been used before
            if (!Directory.Exists(raytwolFolder))
            {
                var warn = new Warning("Setup", "Press OK to begin the first-time setup procedure. Once complete, RayTwol will open.").ShowDialog();
                if (warn.Value)
                    FirstTimeSetup();
            }
            else
            {
                long size = Func.DirectorySize(new DirectoryInfo(raytwolFolder));
                if (!(size == INST_FOLDER_SIZE || size == INST_TEXTURES_FOLDER_SIZE))
                {
                    var warn = new Warning("Warning", "First-time setup is not complete or setup-related files have been modified. If this error persists, press OK to re-initialise the setup.").ShowDialog();
                    if (warn.Value)
                        FirstTimeSetup();
                }
            }
            */
        }

        public List<FileInfo> ReadGameDirectoryLevelFiles(string levelsDirectory)
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
