using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class SettingsTab : Tab
    {
        public ObservableCollection<ProgramObj> ProgramObjects { get; set; }
        private XamlStyles style = new XamlStyles();

        public SettingsTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            ProgramObjects = new ObservableCollection<ProgramObj>(Programs.ProgramObjs);

            TextBlock titleSettings = new TextBlock()
            {
                Text = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock titleOpenProgram = new TextBlock()
            {
                Text = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.TitleLoc,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };
            ProgramObj forTitleProgramObj = new ProgramObj();

            #region Columns

            FrameworkElementFactory nameDGFactory = new FrameworkElementFactory(typeof(TextBox));
            nameDGFactory.SetBinding(TextBox.TextProperty, new Binding(nameof(forTitleProgramObj.Name)));
            nameDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            nameDGFactory.SetValue(TextBox.WidthProperty, (double)100);
            DataTemplate nameDGTemplate = new DataTemplate() 
            {
                VisualTree = nameDGFactory,
            };
            
            FrameworkElementFactory callingNameDGTextBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            callingNameDGTextBoxFactory.SetBinding(TextBox.TextProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            callingNameDGTextBoxFactory.SetValue(TextBox.WidthProperty, (double)100);
            FrameworkElementFactory callingNameDGAddButtonFactory = new FrameworkElementFactory(typeof(Button));
            callingNameDGAddButtonFactory.SetValue(Button.WidthProperty, (double)25);

            FrameworkElementFactory callingNameDGHorizontalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGHorizontalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGTextBoxFactory);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGAddButtonFactory);

            FrameworkElementFactory callingNameDGDeleteButton = new FrameworkElementFactory(typeof(Button));
            callingNameDGDeleteButton.SetValue(Button.WidthProperty, (double)25);
            callingNameDGDeleteButton.SetValue(Button.HeightProperty, (double)25);
            FrameworkElementFactory callingNameDGVerticalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.MarginProperty, new Thickness(0, 5, 0, 5));
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGHorizontalStackPanelFactory);
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGDeleteButton);

            DataTemplate callingNameDGTemplate = new DataTemplate()
            {
                VisualTree = callingNameDGVerticalStackPanelFactory,
            };

            FrameworkElementFactory pathDGFactory = new FrameworkElementFactory(typeof(TextBox));
            pathDGFactory.SetBinding(TextBox.TextProperty, new Binding(nameof(forTitleProgramObj.Path)));
            pathDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            pathDGFactory.SetValue(TextBox.WidthProperty, (double)100);
            pathDGFactory.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            DataTemplate pathDGTemplate = new DataTemplate()
            {
                VisualTree = pathDGFactory,
            };


            DataGridTemplateColumn nameDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.NameLoc,
                CellTemplate = nameDGTemplate,
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            };
            DataGridTemplateColumn callingNamesDataGridColumn = new DataGridTemplateColumn() 
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.CallingNamesLoc,
                CellTemplate = callingNameDGTemplate,
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTemplateColumn pathDataGridColumn = new DataGridTemplateColumn()
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.PathLoc,
                CellTemplate = pathDGTemplate,
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
            };

            //DataGridTextColumn nameDataGridColumn = new DataGridTextColumn()
            //{
            //    Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.NameLoc,
            //    Binding = new Binding(nameof(forTitleProgramObj.Name)),
            //    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            //};
            //DataGridTextColumn callingNamesDataGridColumn = new DataGridTextColumn()
            //{
            //    Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.CallingNamesLoc,
            //    Binding = new Binding(nameof(forTitleProgramObj.CallingNames)),
            //    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            //};
            //DataGridTextColumn pathDataGridColumn = new DataGridTextColumn()
            //{
            //    Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.PathLoc,
            //    Binding = new Binding(nameof(forTitleProgramObj.Path)),
            //    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            //};

            #endregion

            DataGrid programsDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Margin = new Thickness(10, 0, 15, 0),
                ItemsSource = ProgramObjects,
                CellStyle = new DataGridCellStyle(),
                ColumnHeaderStyle = (Style)style.Resources["DataGridColumnHeaderStyle"],
                RowStyle = (Style)style.Resources["DataGridRowStyle"],
                Style = (Style)style.Resources["DataGridStyle"]
            };
            programsDataGrid.Columns.Add(nameDataGridColumn);
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
