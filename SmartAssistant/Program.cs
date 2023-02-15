using SmartAssistant.Data.GreetingsData;
using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.MultiAnswersData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Data.SitesData;
using SmartAssistant.Data.TriggersData;
using SmartAssistant.Data.WordsData;
using SmartAssistant.Models;
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
            new GreetingWords().Deserialize();
            new Localize().Deserialize();
            new MultiAnswers().Deserialize();
            new Programs().Deserialize();
            new Sites().Deserialize();
            new TriggerWords().Deserialize();
            new Words().Deserialize();


            //STT.STT sTT = new STT.STT("ru");
            //sTT.Start();
            //CloseApplicationCommand.CloseApplicationEvent += sTT.Stop;
            //STT.CCSTTF cCSTTF = new STT.CCSTTF();
            //cCSTTF.Start();
            //CloseApplicationCommand.CloseApplicationEvent += cCSTTF.Stop;


            Application app = new Application();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { 
                Source = new Uri("pack://application:,,,/SmartAssistant;component/Infrastructure/Styles/XamlStyles.xaml", 
                    UriKind.RelativeOrAbsolute)
            });


            Window mainWin = new MainWindow();
            StateManager.Initialize();
            SkillManager.Initialize();


            mainWin.Show();
            app.Run();
        }
    }
}
