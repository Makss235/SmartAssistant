using SmartAssistant.Data.LocalizationData;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using SmartAssistant.Data.ProgramsData;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public partial class SettingsTab
    {
        private TextBlock titleProgramsTextBlock;
        private DataGridTemplateColumn nameDataGridColumn;
        private DataGridTemplateColumn callingNamesDataGridColumn;
        private DataGridTemplateColumn pathDataGridColumn;
        private DataGrid programElenentsDataGrid;
        private Button callAddPEWindowButton;
        private StackPanel programSettingsStackPanel;

        public ObservableCollection<ProgramElement> ProgramElements { get; private set; }

        private StackPanel ICProgramSettings()
        {
            InitializePECollection();
            Windows.AddPEWindow.AddPEWindow.AddPEDone += AddPEHandler;

            titleProgramsTextBlock = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };

            #region Columns

            nameDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.NameLoc,
                CellTemplate = new NameDGTemplateColumn(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            };
            callingNamesDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.CallingNamesLoc,
                CellTemplate = new CallingNamesDGTemplateColumn(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            pathDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.PathLoc,
                CellTemplate = new PathDGTemplateColumn(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };

            #endregion

            programElenentsDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                CanUserAddRows = false,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Margin = new Thickness(10, 0, 15, 0),
                ItemsSource = ProgramElements,
                CellStyle = ResApp.GetResources<Style>("DGCellStyle"),
                ColumnHeaderStyle = ResApp.GetResources<Style>("DGColumnHeaderStyle"),
                RowStyle = ResApp.GetResources<Style>("DGRowStyle"),
                Style = ResApp.GetResources<Style>("DGStyle"),
            };
            programElenentsDataGrid.Columns.Add(nameDataGridColumn);
            programElenentsDataGrid.Columns.Add(callingNamesDataGridColumn);
            programElenentsDataGrid.Columns.Add(pathDataGridColumn);

            callAddPEWindowButton = new Button()
            {
                Width = 60,
                Height = 40,
                FontSize = 25,
                Content = "+",
                Padding = new Thickness(0, -5, 0, 0),
                Margin = new Thickness(10),
                Style = new RoundedButton(
                    new CornerRadius(20),
                    new Thickness(2),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
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
            programSettingsStackPanel.Children.Add(programElenentsDataGrid);
            programSettingsStackPanel.Children.Add(callAddPEWindowButton);
            return programSettingsStackPanel;
        }

        private void CallAddPEWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddPEWindow.AddPEWindow addPEWindow = new Windows.AddPEWindow.AddPEWindow();
            addPEWindow.Show();
        }

        private void InitializePECollection()
        {
            ProgramElements = new ObservableCollection<ProgramElement>();
            ProgramElements.CollectionChanged += ProgramElements_CollectionChanged;

            foreach (var programObj in Programs.JsonObject)
            {
                var programElement = new ProgramElement(programObj);
                programElement.PropertyChanged += ProgramElement_PropertyChanged;
                programElement.CallingNames.CollectionChanged += CallingNames_CollectionChanged;
                ProgramElements.Add(programElement);
            }
        }

        private void CallingNames_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Serialize();
        }

        private void ProgramElement_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Serialize();
        }

        private void ProgramElements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Serialize();
        }

        private void AddPEHandler(ProgramElement programElement)
        {
            ProgramElements.Add(programElement);
        }
    }
}
