using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public class MainWindow : Window
    {
        private List<Tab> tabsList;

        public ICommand MouseMoveCommand { get; }
        private bool CanMouseMoveCommandExecute(object sender) => true;
        private void OnMouseMoveCommandExecuted(object sender)
        {
            DragMove();
        }

        public MainWindow()
        {
            MouseMoveCommand = new LambdaCommand(
                OnMouseMoveCommandExecuted,
                CanMouseMoveCommandExecute);

            tabsList = new List<Tab>();

            Width = 800;
            Height = 500;
            Title = Localize.LocObj.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            Grid mainGrid = new Grid();

            ColumnDefinition headingMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(45, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);

            ColumnDefinition leftMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(220, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(leftMenuColumnDefinition);

            ColumnDefinition mainFieldColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(535, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(mainFieldColumnDefinition);

            HeadingMenu headingMenu = new HeadingMenu(MouseMoveCommand);
            Grid.SetColumn(headingMenu.HeadingMenuBorder, 0);

            LeftMenu leftMenu = new LeftMenu();
            Grid.SetColumn(leftMenu.LeftMenuBorder, 1);

            MainField mainField = new MainField();
            Grid.SetColumn(mainField.MainFieldBorder, 2);

            mainGrid.Children.Add(mainField.MainFieldBorder);
            mainGrid.Children.Add(leftMenu.LeftMenuBorder);
            mainGrid.Children.Add(headingMenu.HeadingMenuBorder);

            Content = mainGrid;
        }
    }
}
