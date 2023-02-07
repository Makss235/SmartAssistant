using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using SmartAssistant.UserControls.MainWindow;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;

namespace SmartAssistant.Windows.MainWindow
{
    public class MainWindow : Window
    {
        public static SolidColorBrush BackgroundLightBrush = new SolidColorBrush(Colors.AliceBlue);
        public static SolidColorBrush BackgroundMediumBrush = new SolidColorBrush(Color.FromRgb(51, 146, 255));
        public static SolidColorBrush BackgroundDarkBrush = new SolidColorBrush(Color.FromRgb(0, 119, 255));
        public static SolidColorBrush ForegroundWhiteColor = new SolidColorBrush(Colors.White);

        TextBlock title;

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

            STT.CCSTTF.ChangingTextSTTF += ChangeTextRequest;

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


            title = new TextBlock()
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

            Border headingMenuBorder = new Border();
            headingMenuBorder.Background = BackgroundDarkBrush;
            headingMenuBorder.CornerRadius = new CornerRadius(20);
            headingMenuBorder.Child = headingMenuGrid;
            Grid.SetColumn(headingMenuBorder, 0);


            Grid leftMenuGrid = new Grid();
            MenuButtonUC menuButtonUC = new MenuButtonUC();
            leftMenuGrid.Children.Add(menuButtonUC);

            Border leftMenuBorder = new Border();
            leftMenuBorder.Background = BackgroundMediumBrush;
            leftMenuBorder.CornerRadius = new CornerRadius(0, 20, 20, 0);
            leftMenuBorder.Margin = new Thickness(-20, 0, 0, 0);
            leftMenuBorder.Child = leftMenuGrid;
            Grid.SetColumn(leftMenuBorder, 1);


            Grid mainFieldGrid = new Grid();
            SettingsTab settings_Tab = new SettingsTab();
            mainFieldGrid.Children.Add(settings_Tab);

            Border mainFieldBorder = new Border();
            mainFieldBorder.Background = BackgroundLightBrush;
            mainFieldBorder.CornerRadius = new CornerRadius(0, 20, 20, 0);
            mainFieldBorder.Margin = new Thickness(-20, 0, 0, 0);
            mainFieldBorder.Child = mainFieldGrid;
            Grid.SetColumn(mainFieldBorder, 2);


            mainGrid.Children.Add(mainFieldBorder);
            mainGrid.Children.Add(leftMenuBorder);
            mainGrid.Children.Add(headingMenuBorder);

            Content = mainGrid;
        }

        public void ChangeTextRequest(string text)
        {
            Dispatcher.Invoke(() => title.Text = text);
        }
    }
}
