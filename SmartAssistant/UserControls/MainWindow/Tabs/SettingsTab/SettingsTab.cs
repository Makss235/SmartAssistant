using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class SettingsTab : Tab
    {
        public ObservableCollection<ProgramObj> ProgramObjects { get; set; }

        public SettingsTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            ProgramObjects = new ObservableCollection<ProgramObj>(Programs.JsonObject);

            TextBlock titleSettings = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock titleOpenProgram = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };
            ProgramObj forTitleProgramObj = new ProgramObj();

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
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            };

            #endregion

            DataGrid programsDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Margin = new Thickness(10, 0, 15, 0),
                ItemsSource = ProgramObjects,
                CellStyle = Application.Current.Resources["DGCellStyle1"] as Style,
                ColumnHeaderStyle = Application.Current.Resources["DGColumnHeaderStyle"] as Style /*new DataGridColumnHeaderStyle()*/,
                RowStyle = Application.Current.Resources["DGRowStyle"] as Style,
                Style = Application.Current.Resources["DGStyle"] as Style
            };
            //programsDataGrid.Columns.Add(nameDataGridColumn);
            programsDataGrid.Columns.Add(callingNamesDataGridColumn);
            programsDataGrid.Columns.Add(pathDataGridColumn);

            StackPanel stackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            stackPanel1.Children.Add(titleOpenProgram);
            stackPanel1.Children.Add(programsDataGrid);

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0)
            };
            stackPanel.Children.Add(stackPanel1);

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 45, 0, 20),
                Visibility = Visibility.Visible
            };
            scrollViewer.Content = stackPanel;

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(titleSettings);
            mainGrid.Children.Add(scrollViewer);

            Content = mainGrid;
        }
    }
}
