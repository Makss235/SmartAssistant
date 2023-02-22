using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.Windows.MainWindow
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Width = 850;
            Height = 550;
            Title = Localize.JsonObject.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            Grid mainGrid = new Grid()
            {
                Width = 800,
                Height = 500
            };

            ColumnDefinition headingMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(45, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);

            ColumnDefinition leftMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(220, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(leftMenuColumnDefinition);

            ColumnDefinition mainFieldColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(535, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(mainFieldColumnDefinition);

            HeadingMenu headingMenu = new HeadingMenu(new DragMoveCommand(this));
            Grid.SetColumn(headingMenu.HeadingMenuBorder, 0);

            LeftMenu leftMenu = new LeftMenu();
            Grid.SetColumn(leftMenu.LeftMenuBorder, 1);

            MainField mainField = new MainField();
            Grid.SetColumn(mainField.MainFieldBorder, 2);

            mainGrid.Children.Add(mainField.MainFieldBorder);
            mainGrid.Children.Add(leftMenu.LeftMenuBorder);
            mainGrid.Children.Add(headingMenu.HeadingMenuBorder);

            DropShadowEffect dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 5,
                BlurRadius = 15,
                Opacity = 0.5
            };

            Content = mainGrid;
            Effect = dropShadowEffect;
        }
    }
}
