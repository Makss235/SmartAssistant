using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartAssistant.Windows
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Width = 800;
            Height = 500;
            Title = "Привет, Иван!";

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);


            Grid mainGrid = new Grid();

            ColumnDefinition headingMenuColumnDefinition = new ColumnDefinition();
            headingMenuColumnDefinition.Width = new GridLength(45, GridUnitType.Pixel);


            ColumnDefinition leftMenuColumnDefinition = new ColumnDefinition();
            leftMenuColumnDefinition.Width = new GridLength(220, GridUnitType.Pixel);

            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);
            mainGrid.ColumnDefinitions.Add(leftMenuColumnDefinition);


            Content = mainGrid;

            Border headingMenuBorder = new Border();
            headingMenuBorder.Background = new SolidColorBrush(Colors.AliceBlue);
            headingMenuBorder.Width = 100;

            Border leftMenuBorder = new Border();
        }
    }
}
