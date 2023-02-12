using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.MultiAnswersData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Data.WordsData;
using SmartAssistant.Data.TriggersData;
using SmartAssistant.Models;
using SmartAssistant.Windows.MainWindow;
using System;
using System.Windows;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Data.SitesData;

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
            Programs.Init("ru");
            MultiAnswers.Init("ru");
            Sites.Init("ru");

            STT.STT sTT = new STT.STT("ru");
            sTT.Start();
            CloseApplicationCommand.CloseApplicationEvent += sTT.Stop;
            STT.CCSTTF cCSTTF = new STT.CCSTTF();
            cCSTTF.Start();
            CloseApplicationCommand.CloseApplicationEvent += cCSTTF.Stop;

            StateManager.Initialize();
            SkillManager.Initialize();

            Window mainWin = new MainWindow();
            mainWin.Show();
            Application app = new Application();
            app.Run();
        }
    }
}
