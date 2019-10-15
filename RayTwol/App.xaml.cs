using System;

namespace RayTwol
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            /*
            Action<string, string> displayMessage = DisplayMessage;

            RayTwolCore.Launcher launcher = new RayTwolCore.Launcher(displayMessage);

            launcher.Init();
            */
            Editor.Init();
        }

        private static void DisplayMessage(string title, string message)
        {
            var warning = new Warning(title, message).ShowDialog();
            if (warning.Value)
            {
                var dl = new Downloader();
                dl.ShowDialog();
                if ((bool)!dl.DialogResult)
                    Environment.Exit(0);
            }
            else
                Environment.Exit(0);
        }
    }
}
