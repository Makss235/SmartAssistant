using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using SmartAssistant.Views.MainWindow.Tabs;

namespace SmartAssistant.Views.MainWindow
{
    public class MainWindow : Window
    {
        public static SolidColorBrush BackgroundLightBrush = new SolidColorBrush(Colors.AliceBlue);
        public static SolidColorBrush BackgroundMediumBrush = new SolidColorBrush(Color.FromRgb(51, 146, 255));
        public static SolidColorBrush BackgroundDarkBrush = new SolidColorBrush(Color.FromRgb(0, 119, 255));
        public static SolidColorBrush ForegroundWhiteColor = new SolidColorBrush(Colors.White);

        public MainWindow()
        {
            Width = 800;
            Height = 500;
            Title = "Привет, Иван!";

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;



            TextBlock title = new TextBlock()
            {
                Text = Title,
                Foreground = ForegroundWhiteColor,
                Background = new SolidColorBrush(Colors.Transparent),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 25, 0, 0),
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                LayoutTransform = new RotateTransform() { Angle = 90 }
            };

            Grid headingMenuGrid = new Grid();
            headingMenuGrid.Children.Add(title);


            Grid grid = new Grid();
            Settings_Tab settings_Tab = new Settings_Tab();
            grid.Children.Add(settings_Tab);


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

            Content = mainGrid;

            Border headingMenuBorder = new Border();
            headingMenuBorder.Background = BackgroundDarkBrush;
            headingMenuBorder.CornerRadius = new CornerRadius(20);
            headingMenuBorder.Child = headingMenuGrid;
            Grid.SetColumn(headingMenuBorder, 0);

            Border leftMenuBorder = new Border();
            leftMenuBorder.Background = BackgroundMediumBrush;
            leftMenuBorder.CornerRadius = new CornerRadius(0, 20, 20, 0);
            leftMenuBorder.Margin = new Thickness(-20, 0, 0, 0);
            Grid.SetColumn(leftMenuBorder, 1);

            Border mainFieldBorder = new Border();
            mainFieldBorder.Background = BackgroundLightBrush;
            mainFieldBorder.CornerRadius = new CornerRadius(0, 20, 20, 0);
            mainFieldBorder.Margin = new Thickness(-20, 0, 0, 0);
            mainFieldBorder.Child = grid;
            Grid.SetColumn(mainFieldBorder, 2);

            mainGrid.Children.Add(mainFieldBorder);
            mainGrid.Children.Add(leftMenuBorder);
            mainGrid.Children.Add(headingMenuBorder);
        }
    }
}
