using SmartAssistant.Data.Localization;
using SmartAssistant.UserControls.MainWindow;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.MainWindow
{
    public class LeftMenu
    {
        public Border LeftMenuBorder { get; set; }

        public LeftMenu()
        {
            StackPanel menuButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 175, 0, 0)
            };
            MenuButtonUC vAChatMenuButton = new MenuButtonUC(
                title: Localize.LocObj.MainWindowLoc.MenuButtonsLoc.VAChatButtonTitleLoc, 
                isActive: true, id: 0);
            MenuButtonUC settingsMenuButton = new MenuButtonUC(
                title: Localize.LocObj.MainWindowLoc.MenuButtonsLoc.SettingsButtonTitleLoc, 
                isActive: false, id: 1);
            menuButtonsStackPanel.Children.Add(vAChatMenuButton);
            menuButtonsStackPanel.Children.Add(settingsMenuButton);

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
    }
}
