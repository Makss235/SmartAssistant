﻿using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.MainWindow;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private List<MenuButton> menuButtons;

        private MenuButton vAChatMenuButton;
        private MenuButton settingsMenuButton;
        private MenuButton aboutMenuButton;
        private StackPanel menuButtonsStackPanel;
        private Grid leftMenuGrid;
        private Border leftMenuColBorder;

        private Border ICLeftMenuCol()
        {
            menuButtons = new List<MenuButton>();

            vAChatMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.VAChatButtonTitleLoc,
                isActive: true, id: 0);
            vAChatMenuButton.ButtonPressed += MenuButtonPressedHandler;
            menuButtons.Add(vAChatMenuButton);

            settingsMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.SettingsButtonTitleLoc,
                isActive: false, id: 1);
            settingsMenuButton.ButtonPressed += MenuButtonPressedHandler;
            menuButtons.Add(settingsMenuButton);

            aboutMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.AboutProgramButtonTitleLoc,
                isActive: false, id: 2);
            aboutMenuButton.ButtonPressed += MenuButtonPressedHandler;
            menuButtons.Add(aboutMenuButton);

            menuButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 175, 0, 0)
            };
            menuButtonsStackPanel.Children.Add(vAChatMenuButton);
            menuButtonsStackPanel.Children.Add(settingsMenuButton);
            menuButtonsStackPanel.Children.Add(aboutMenuButton);

            leftMenuGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };
            leftMenuGrid.Children.Add(menuButtonsStackPanel);

            leftMenuColBorder = new Border()
            {
                Background = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                CornerRadius = new CornerRadius(1, 20, 20, 0),
                Margin = new Thickness(-20, 0, 0, 0)
            };
            leftMenuColBorder.Child = leftMenuGrid;
            return leftMenuColBorder;
        }

        private void MenuButtonPressedHandler(byte id)
        {
            for (int i = 0; i < menuButtons.Count; i++)
            {
                if (id == menuButtons[i].ID)
                {
                    menuButtons[i].IsActive = true;
                    tabs[i].Visibility = Visibility.Visible;
                }
                else
                {
                    menuButtons[i].IsActive = false;
                    tabs[i].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
