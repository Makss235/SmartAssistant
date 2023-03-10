using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public partial class SettingsTab : Tab
    {
        private TextBlock titleSettingsTextBlock;
        private StackPanel settingsStackPanel;
        private ScrollViewer mainScrollViewer;
        private Grid mainGrid;

        public SettingsTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            this.Style = ResApp.GetResources<Style>("TabStyle");
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            titleSettingsTextBlock = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            settingsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0)
            };
            settingsStackPanel.Children.Add(ICProgramSettings());

            mainScrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 45, 8, 25),
                Visibility = Visibility.Visible,
                Style = ResApp.GetResources<Style>("ScrollViewerStyle"),
            };
            mainScrollViewer.Content = settingsStackPanel;

            mainGrid = new Grid();
            mainGrid.Children.Add(titleSettingsTextBlock);
            mainGrid.Children.Add(mainScrollViewer);

            Content = mainGrid;
        }

        private void Serialize()
        {
            var programObjs = new List<ProgramObj>();
            foreach (var programElement in ProgramElements)
            {
                programObjs.Add(new ProgramObj()
                {
                    Name = programElement.Name,
                    CallingNames = programElement.CallingNames.ToList(),
                    Path = programElement.Path,
                });
            }
            Programs.JsonObject = programObjs;
            new Programs().Serialize();
        }
    }
}
