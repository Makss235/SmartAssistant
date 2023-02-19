using SmartAssistant.Data.LocalizationData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Windows.AddPE
{
    public class AddPEWindow : Window
    {
        public AddPEWindow()
        {
            Width = 500;
            Height = 350;
            Title = Localize.JsonObject.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            Grid mainGrid = new Grid();

            RowDefinition headingMenuColumnDefinition = new RowDefinition()
            { Height = new GridLength(90, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(headingMenuColumnDefinition);

            RowDefinition headingMenuColumnDefinition1 = new RowDefinition()
            { Height = new GridLength(260, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(headingMenuColumnDefinition1);

            Grid grid = new Grid();

            Border border = new Border()
            {
                Background = new SolidColorBrush(Colors.AliceBlue),
                CornerRadius = new CornerRadius(20, 20, 0, 0),
                BorderThickness = new Thickness(3, 3, 3, 0),
                BorderBrush = new SolidColorBrush(Colors.Black),
            };
            Grid.SetRow(border, 0);

            Border border1 = new Border()
            {
                Background = new SolidColorBrush(Colors.AliceBlue),
                CornerRadius = new CornerRadius(0, 0, 20, 20)
            };
            Grid.SetRow(border1, 1);

            mainGrid.Children.Add(border);
            mainGrid.Children.Add(border1);
            Content = mainGrid;
        }
    }
}
