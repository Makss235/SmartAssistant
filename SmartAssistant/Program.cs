using SmartAssistant.Windows;
using System;
using System.Windows;

namespace SmartAssistant
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Window mainWin = new MainWindow();
            mainWin.Show();
            Application app = new Application();
            app.Run();
        }
    }
}
