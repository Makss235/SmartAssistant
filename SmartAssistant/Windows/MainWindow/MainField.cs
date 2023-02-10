﻿using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.MainWindow
{
    public class MainField
    {
        private List<Tab> tabs;

        public Border MainFieldBorder { get; set; }

        public MainField()
        {
            MenuButtonUC.MenuButtonPressedEvent += ChangeVisibilityTabs;
            tabs = new List<Tab>();

            Grid mainFieldGrid = new Grid();
            VAChatTab vAChatTab = new VAChatTab(id: 0, width: 555, 
                height: 500, visibility: Visibility.Visible);
            SettingsTab settingsTab = new SettingsTab(id: 1, width: 555,
                height: 500, visibility: Visibility.Hidden);

            Button wrapProgramButton = new Button()
            {
                Content = "-",
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 40,
                Height = 36,
                Margin = new Thickness(0, 0, 40, 0),
                BorderThickness = new Thickness(0, 0, 0, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = false
            };

            Button collapseProgramButton = new Button()
            {
                Content = "X",
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 40,
                Height = 36,
                BorderThickness = new Thickness(0, 0, 0, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = true
            };

            mainFieldGrid.Children.Add(vAChatTab);
            tabs.Add(vAChatTab);
            mainFieldGrid.Children.Add(settingsTab);
            tabs.Add(settingsTab);
            mainFieldGrid.Children.Add(collapseProgramButton);
            mainFieldGrid.Children.Add(wrapProgramButton);

            MainFieldBorder = new Border()
            {
                Background = BasicColors.BackgroundLightBrush,
                CornerRadius = new CornerRadius(0, 20, 20, 0),
                Margin = new Thickness(-20, 0, 0, 0)
            };
            MainFieldBorder.Child = mainFieldGrid;
        }

        private void ChangeVisibilityTabs(byte id)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (id == tabs[i].ID)
                {
                    tabs[i].Visibility = Visibility.Visible;
                }
                else
                {
                    tabs[i].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}