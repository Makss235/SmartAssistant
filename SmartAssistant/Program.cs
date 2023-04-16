using SmartAssistant.Data.GreetingsData;
using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.MultiAnswersData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Data.SettingsData;
using SmartAssistant.Data.SitesData;
using SmartAssistant.Data.TriggersData;
using SmartAssistant.Data.WordsData;
using SmartAssistant.Models;
using SmartAssistant.Windows.AddCNWindow;
using SmartAssistant.Windows.MainWindow;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using SmartAssistant.UserControls.Base;
using System.Windows.Threading;
using SmartAssistant.Windows;

namespace SmartAssistant
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Settings.Initialization();
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
            TTS.Initialize();


            Application app = new Application();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { 
                Source = new Uri("pack://application:,,,/SmartAssistant;component/Infrastructure/Styles/XamlStyles.xaml", 
                    UriKind.RelativeOrAbsolute)
            });


            Window mainWin = new MainWindow();
            app.MainWindow = mainWin;
            StateManager.Initialize();
            SkillManager.Initialize();
            
            mainWin.Show();
            //TestWindow testWindow = new TestWindow();
            //testWindow.Show();
            //AddCNWindow addCallingNameWindow = new AddCNWindow(new Point(mainWin.Left, mainWin.Top));
            //addCallingNameWindow.Show();

            app.Run();
        }
    }
}
