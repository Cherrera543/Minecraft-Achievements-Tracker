using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace Minecraft_Achievements
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.VisualStyleState = VisualStyleState.NonClientAreaEnabled;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}