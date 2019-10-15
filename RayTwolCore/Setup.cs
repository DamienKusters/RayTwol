using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public enum ValidationStatus
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
        public const long INST_FOLDER_SIZE = 38341965;
        public const long INST_TEXTURES_FOLDER_SIZE = 19150935;
        public const long INST_LEVELS0_SIZE = 150775808;

        /// <summary>
        /// Checks the game file integrity of the directory.
        /// </summary>
        /// <param name="gameDirectory"></param>
        /// <returns>enum ValidationError</returns>
        public ValidationStatus ValidateGameDirectory(string gameDirectory)
        {
            if (!Directory.Exists(gameDirectory + @"\Data\World\Levels"))
                return ValidationStatus.LevelsFolderMissing;

            return ValidateFileIntegrity(gameDirectory);
        }

        private ValidationStatus ValidateFileIntegrity(string levelsDirectory)//TODO: Merge with ValidateGameDirectory
        {
            string levels0File = levelsDirectory + "\\LEVELS0.DAT";
            string raytwolFolder = levelsDirectory + "\\_raytwol";

            // Check for LEVELS0.DAT
            if (!File.Exists(levels0File))
                return ValidationStatus.LevelsDataFileMissing;
            else if (new FileInfo(levels0File).Length != INST_LEVELS0_SIZE)
                return ValidationStatus.LevelsDataFileCorrupt;

            // Check if RayTwol has been used before
            if (!Directory.Exists(raytwolFolder))
                return ValidationStatus.RayTwolFolderMissing;
            else
            {
                long size = GetDirectorySize(new DirectoryInfo(raytwolFolder));
                if (!(size == INST_FOLDER_SIZE || size == INST_TEXTURES_FOLDER_SIZE))
                    return ValidationStatus.FolderSizeIntegrityError;
            }

            return ValidationStatus.Successful;
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
            ConfigurationManager config = new ConfigurationManager();

            try
            {
                return config.GetConfigFileValue("dir");
            }
            catch (FileNotFoundException ex)
            {
                //TODO: Notify user / Or start setup
                throw;
            }
        }

        public long GetDirectorySize(DirectoryInfo dirInfo)
        {
            long totalSize = 0;

            // Add file sizes.
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                totalSize += file.Length;
            }

            // Add subdirectory sizes.
            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                totalSize += GetDirectorySize(directory);
            }

            return totalSize;
        }
    }
}
