using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.Base;
using SmartAssistant.Windows.AddPEWindow;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class SettingsTab : Tab, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public ObservableCollection<ProgramElement> ProgramElements { get; set; }

        public SettingsTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            ProgramElements = new ObservableCollection<ProgramElement>();
            MainFieldRow.privet += MainFieldRow_privet;
            CollectionChanged += SettingsTab_CollectionChanged;

            InitializeCollection();
            InitializeComponent();
        }

        private void SettingsTab_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Serialize();
        }

        private void MainFieldRow_privet(ProgramElement obj)
        {
            ProgramElements.Add(obj);
            Serialize();
        }

        private void InitializeComponent()
        {
            TextBlock titleSettings = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock titlePrograms = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };

            #region Columns

            DataGridTemplateColumn nameDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.NameLoc,
                CellTemplate = new NameDGTemplate(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            };
            DataGridTemplateColumn callingNamesDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.CallingNamesLoc,
                CellTemplate = new CallingNameDGTemplate(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTemplateColumn pathDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.PathLoc,
                CellTemplate = new PathDGTemplate(),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };

            #endregion

            DataGrid programsDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                CanUserAddRows = false,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Margin = new Thickness(10, 0, 15, 0),
                ItemsSource = ProgramElements,
                CellStyle = Application.Current.Resources["DGCellStyle1"] as Style,
                ColumnHeaderStyle = Application.Current.Resources["DGColumnHeaderStyle"] as Style /*new DataGridColumnHeaderStyle()*/,
                RowStyle = Application.Current.Resources["DGRowStyle"] as Style,
                Style = Application.Current.Resources["DGStyle"] as Style,
            };
            programsDataGrid.Columns.Add(nameDataGridColumn);
            programsDataGrid.Columns.Add(callingNamesDataGridColumn);
            programsDataGrid.Columns.Add(pathDataGridColumn);

            StackPanel programsSP = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            programsSP.Children.Add(titlePrograms);
            programsSP.Children.Add(programsDataGrid);

            StackPanel settingsSP = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0)
            };
            settingsSP.Children.Add(programsSP);

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 45, 8, 25),
                Visibility = Visibility.Visible
            };
            scrollViewer.Content = settingsSP;

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(titleSettings);
            mainGrid.Children.Add(scrollViewer);

            Content = mainGrid;
        }

        private void InitializeCollection()
        {
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
            MessageBox.Show("Serialize ProgramElement_PropertyChanged");
            Serialize();
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
