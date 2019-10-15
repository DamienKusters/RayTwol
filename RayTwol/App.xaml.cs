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
            Func<string, string, bool> displayMessage = DisplayMessage;//Func to run if the launcher needs User input to proceed.

            RayTwolCore.Launcher launcher = new RayTwolCore.Launcher(displayMessage);

            if (launcher.Init())
                new MainWindow().ShowDialog();
            else
                DisplayMessage("Error", "An unknown error occured.");
            */

            Editor.Init();
        }

        private static bool DisplayMessage(string title, string message) => new Warning(title, message).ShowDialog().Value;
    }
}
