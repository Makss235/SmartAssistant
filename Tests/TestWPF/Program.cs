using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SmartAssistant.UserControls.Widgets;

namespace TestWPF
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var main = new MainWindow();
            main.Show();
            var app = new Application();
            app.Run();
        }
    }
}
