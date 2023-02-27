﻿using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.AboutTab;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private List<Tab> tabs;

        private VAChatTab vAChatTab;
        private SettingsTab settingsTab;
        private AboutTab aboutTab;
        private Button wrapProgramButton;
        private Button collapseProgramButton;
        private Grid mainFieldGrid;
        private Border mainFieldColBorder;

        private Border ICMainFieldCol()
        {
            tabs = new List<Tab>();

            vAChatTab = new VAChatTab(id: 0, width: 535,
                height: 500, visibility: Visibility.Visible);
            tabs.Add(vAChatTab);
            settingsTab = new SettingsTab(id: 1, width: 535,
                height: 500, visibility: Visibility.Hidden);
            tabs.Add(settingsTab);
            aboutTab = new AboutTab(id: 2, width: 535,
                height: 500, visibility: Visibility.Hidden);
            tabs.Add(aboutTab);

            // TODO: Veser картинки на кнопки закрытия и сворачивания программы
            wrapProgramButton = new Button()
            {
                Style = new WarpAndCollapseProgramButtonStyle(0, 20, 40, Application.Current.Resources["BackgroundDarkBrush"] as SolidColorBrush),
                Content = "-",
                Command = new CloseApplicationCommand(),
                CommandParameter = false
            };

            collapseProgramButton = new Button()
            {
                Style = new WarpAndCollapseProgramButtonStyle(15, 0, 0, Application.Current.Resources["Red"] as SolidColorBrush),
                Content = "X",
                Command = new CloseApplicationCommand(),
                CommandParameter = true
            };

            mainFieldGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };

            mainFieldGrid.Children.Add(vAChatTab);
            mainFieldGrid.Children.Add(settingsTab);
            mainFieldGrid.Children.Add(aboutTab);
            mainFieldGrid.Children.Add(collapseProgramButton);
            mainFieldGrid.Children.Add(wrapProgramButton);

            mainFieldColBorder = new Border()
            {
                Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush,
                CornerRadius = new CornerRadius(0, 20, 20, 0),
                Margin = new Thickness(-20, 0, 0, 0),
                BorderThickness = new Thickness(4),
                BorderBrush = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush
            };
            mainFieldColBorder.InputBindings.Add(dragMoveIB);
            mainFieldColBorder.Child = mainFieldGrid;
            return mainFieldColBorder;
        }
    }
}
