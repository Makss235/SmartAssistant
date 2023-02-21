using SmartAssistant.Data.LocalizationData;
using SmartAssistant.UserControls.MainWindow;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.MainWindow
{
    public class LeftMenu
    {
        private List<MenuButton> _menuButtons;

        public Border LeftMenuBorder { get; set; }

        public LeftMenu()
        {
            _menuButtons = new List<MenuButton>();

            StackPanel menuButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 175, 0, 0)
            };
            MenuButton vAChatMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.VAChatButtonTitleLoc, 
                isActive: true, id: 0);
            _menuButtons.Add(vAChatMenuButton);
            MenuButton settingsMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.SettingsButtonTitleLoc, 
                isActive: false, id: 1);
            _menuButtons.Add(settingsMenuButton);
            MenuButton aboutMenuButton = new MenuButton(
                title: Localize.JsonObject.MainWindowLoc.MenuButtonsLoc.AboutProgramButtonTitleLoc,
                isActive: false, id: 2);
            _menuButtons.Add(aboutMenuButton);
            menuButtonsStackPanel.Children.Add(vAChatMenuButton);
            menuButtonsStackPanel.Children.Add(settingsMenuButton);
            menuButtonsStackPanel.Children.Add(aboutMenuButton);

            MenuButton.MenuButtonPressedEvent += ass;

            Grid leftMenuGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };
            leftMenuGrid.Children.Add(menuButtonsStackPanel);

            LeftMenuBorder = new Border()
            {
                Background = BasicColors.BackgroundMediumBrush,
                CornerRadius = new CornerRadius(1, 20, 20, 0),
                Margin = new Thickness(-20, 0, 0, 0)
            };
            LeftMenuBorder.Child = leftMenuGrid;
        }

        private void ass(byte id)
        {
            for (int i = 0; i < _menuButtons.Count; i++)
            {
                if (id == _menuButtons[i].ID)
                {
                    _menuButtons[i].IsActive = true;
                }
                else
                {
                    _menuButtons[i].IsActive = false;
                }
            }
        }
    }
}
