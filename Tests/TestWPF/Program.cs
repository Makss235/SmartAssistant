using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application application = new Application();
            application.Run();
        }
    }
}
