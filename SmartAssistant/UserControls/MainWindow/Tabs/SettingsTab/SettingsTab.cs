﻿using SmartAssistant.Data.LocalizationData;
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

            DataGridTextColumn nameDataGridColumn = new DataGridTextColumn()
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.NameLoc,
                Binding = new Binding(nameof(forTitleProgramObj.Name)),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTextColumn callingNamesDataGridColumn = new DataGridTextColumn()
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.CallingNamesLoc,
                Binding = new Binding(nameof(forTitleProgramObj.CallingNames)),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };
            DataGridTextColumn pathDataGridColumn = new DataGridTextColumn()
            {
                Header = Localize.LocObj.MainWindowLoc.TabsLoc.SettingsTabLoc.OpenProgramLoc.DataGridColumnsLoc.PathLoc,
                Binding = new Binding(nameof(forTitleProgramObj.Path)),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };

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
