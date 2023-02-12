using SmartAssistant.Data;
using SmartAssistant.Data.Localization;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Models;
using SmartAssistant.Properties;
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
            Localize.Init("ru");
            Words.Init("ru");

            STT.STT sTT = new STT.STT("ru");
            sTT.Start();
            CloseApplicationCommand.CloseApplicationEvent += sTT.Stop;
            STT.CCSTTF cCSTTF = new STT.CCSTTF();
            cCSTTF.Start();
            CloseApplicationCommand.CloseApplicationEvent += cCSTTF.Stop;

            StateManager.Initialize();
            SpeechManager.Initialize();
            SetSkills.Initialize();

            Window mainWin = new MainWindow();
            mainWin.Show();
            Application app = new Application();
            app.Run();
        }
    }
}
