using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public partial class SettingsTab
    {
        private TextBlock titleProgramsTextBlock;
        private StackPanel programsStackPanel;
        private Button callAddPEWindowButton;
        private StackPanel programSettingsStackPanel;

        public event Action<bool, bool, bool> AddPEChecked;

        public ObservableCollection<ProgramElement> ProgramElements { get; private set; }

        private StackPanel ICProgramSettings()
        {
            InitializePECollection();

            Programs.Serialized += Programs_Serialized;

            titleProgramsTextBlock = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.MainWindowTabsLoc.SettingsTabLoc.ProgramSettingsLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };

            programsStackPanel = new StackPanel();

            for (int i = 0; i < Programs.JsonObject.Count; i++)
            {
                PE pE = new PE(Programs.JsonObject[i]);
                pE.A += (s) => programsStackPanel.Children.Remove(s);
                programsStackPanel.Children.Add(pE);
            }

            callAddPEWindowButton = new Button()
            {
                Width = 50,
                Height = 50,
                FontSize = 30,
                Content = "+",
                Padding = new Thickness(0, -5, 0, 0),
                Margin = new Thickness(10),
                Style = new RoundedButton(
                    new CornerRadius(25),
                    new Thickness(2),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"))
            };
            callAddPEWindowButton.Click += CallAddPEWindowButton_Click;

            programSettingsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            programSettingsStackPanel.Children.Add(titleProgramsTextBlock);
            programSettingsStackPanel.Children.Add(programsStackPanel);
            programSettingsStackPanel.Children.Add(callAddPEWindowButton);

            return programSettingsStackPanel;
        }

        private void Programs_Serialized()
        {
            programsStackPanel.Children.Clear();

            for (int i = 0; i < Programs.JsonObject.Count; i++)
            {
                programsStackPanel.Children.Add(new PE(Programs.JsonObject[i]));
            }
        }

        private void CallAddPEWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddPEWindow.AddPEWindow addPEWindow = new Windows.AddPEWindow.AddPEWindow(this);
            addPEWindow.AddPEDone += AddPEHandler;
            addPEWindow.Show();
        }

        private void InitializePECollection()
        {
            ProgramElements = new ObservableCollection<ProgramElement>();
            ProgramElements.CollectionChanged += (s, e) => Serialize();

            foreach (var programObj in Programs.JsonObject)
            {
                var programElement = new ProgramElement(programObj);
                programElement.PropertyChanged += (s, e) => Serialize();
                programElement.CallingNames.CollectionChanged += (s, e) => Serialize();
                ProgramElements.Add(programElement);
            }
        }

        private void AddPEHandler(ProgramElement pe)
        {
            bool resultCheckName = true;
            bool resultCheckCN = true;
            for (int i = 0; i < ProgramElements.Count; i++)
            {
                ProgramElement currentPE = ProgramElements[i];
                if (currentPE.Name == pe.Name)
                {
                    resultCheckName = false;
                }
                for (int j = 0; j < pe.CallingNames.Count; j++)
                {
                    for (int k = 0; k < currentPE.CallingNames.Count; k++)
                    {
                        if (currentPE.CallingNames[k] == pe.CallingNames[j])
                        {
                            resultCheckCN = false;
                        }
                    }
                }
            }

            AddPEChecked?.Invoke(resultCheckName, resultCheckCN, true);
            if (resultCheckName && resultCheckCN)
            {
                ProgramElements.Add(pe);
            }
        }
    }
}
