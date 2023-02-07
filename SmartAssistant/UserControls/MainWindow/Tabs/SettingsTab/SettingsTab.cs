﻿using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class SettingsTab : UserControl
    {
        public SettingsTab()
        {
            TextBlock title = new TextBlock()
            {
                Text = "Настройки",
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock titleProgram = new TextBlock()
            {
                Text = "Программы",
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 16,
                Margin = new Thickness(20, 10, 0, 10),
            };
            DataGridTextColumn nameDataGridColumn = new DataGridTextColumn()
            {
                Header = "Имя программы"
            };

            DataGrid programDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Margin = new Thickness(10, 0, 15, 0),
            };

            StackPanel stackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            stackPanel1.Children.Add(titleProgram);
            stackPanel1.Children.Add(programDataGrid);

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(30, 0, 0, 0)
            };
            stackPanel.Children.Add(stackPanel1);

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 45, 0, 20),
                Visibility = Visibility.Visible
            };
            scrollViewer.Content = stackPanel;

            Grid mainGrid = new Grid();
            mainGrid.Margin = new Thickness(20, 0, 0, 0);
            mainGrid.Children.Add(title);
            mainGrid.Children.Add(scrollViewer);

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.Transparent),
                Width = 555,
                Height = 500
            };
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}