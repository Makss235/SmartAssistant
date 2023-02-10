using SmartAssistant.Data;
using SmartAssistant.Windows.MainWindow;
using System;
using System.Windows;

namespace SmartAssistant
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            TriggerWords.Init("ru");

            //STT.STT sTT = new STT.STT("ru");
            //sTT.Start();
            //STT.CCSTTF cCSTTF = new STT.CCSTTF();
            //cCSTTF.Start();

            Window mainWin = new MainWindow();
            mainWin.Show();
            Application app = new Application();
            app.Run();
        }
    }
}
