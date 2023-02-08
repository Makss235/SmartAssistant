using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SmartAssistant.Windows.MainWindow
{
    public class MainWindow : Window
    {
        public static SolidColorBrush BackgroundLightBrush = new SolidColorBrush(Colors.AliceBlue);
        public static SolidColorBrush BackgroundMediumBrush = new SolidColorBrush(Color.FromRgb(51, 146, 255));
        public static SolidColorBrush BackgroundDarkBrush = new SolidColorBrush(Color.FromRgb(0, 119, 255));
        public static SolidColorBrush ForegroundWhiteColor = new SolidColorBrush(Colors.White);

        private TextBlock title;
        private List<Tab> tabsList;

        public MainWindow()
        {
            tabsList = new List<Tab>();
            MouseMoveCommand = new LambdaCommand(
                OnMouseMoveCommandExecuted,
                CanMouseMoveCommandExecute);

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

            InputBinding MouseMoveIB = new InputBinding(MouseMoveCommand, new MouseGesture()
            {
                MouseAction = MouseAction.LeftClick
            });

            Border headingMenuBorder = new Border();
            headingMenuBorder.Background = BackgroundDarkBrush;
            headingMenuBorder.CornerRadius = new CornerRadius(20);
            headingMenuBorder.Child = headingMenuGrid;
            headingMenuBorder.InputBindings.Add(MouseMoveIB);
            Grid.SetColumn(headingMenuBorder, 0);


            StackPanel menuButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 175, 0, 0)
            };
            MenuButtonUC vAChatMenuButton = new MenuButtonUC(
                title: "Главная", isActive: true, id: 0, 
                tabsList: tabsList);
            MenuButtonUC settingsMenuButton = new MenuButtonUC(
                title: "Настройки", isActive: false, id: 1,
                tabsList: tabsList);
            menuButtonsStackPanel.Children.Add(vAChatMenuButton);
            menuButtonsStackPanel.Children.Add(settingsMenuButton);

            Grid leftMenuGrid = new Grid();
            leftMenuGrid.Children.Add(menuButtonsStackPanel);

            Border leftMenuBorder = new Border();
            leftMenuBorder.Background = BackgroundMediumBrush;
            leftMenuBorder.CornerRadius = new CornerRadius(0, 20, 20, 0);
            leftMenuBorder.Margin = new Thickness(-20, 0, 0, 0);
            leftMenuBorder.Child = leftMenuGrid;
            Grid.SetColumn(leftMenuBorder, 1);


            Grid mainFieldGrid = new Grid();
            VAChatTab vAChatTab = new VAChatTab()
            {
                ID = 0,
                Width = mainFieldColumnDefinition.Width.Value + 20,
                Height = Height,
                Visibility = Visibility.Visible
            };
            SettingsTab settingsTab = new SettingsTab()
            {
                ID = 1,
                Width = mainFieldColumnDefinition.Width.Value + 20,
                Height = Height,
                Visibility = Visibility.Hidden
            };

            Button wrapProgramButton = new Button()
            {
                Content = "-",
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 40,
                Height = 36,
                Margin = new Thickness(0, 0, 40, 0),
                BorderThickness = new Thickness(0, 0, 0, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = false
            };

            Button collapseProgramButton = new Button()
            {
                Content = "X",
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 40,
                Height = 36,
                BorderThickness = new Thickness(0, 0, 0, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = true
            };

            mainFieldGrid.Children.Add(vAChatTab);
            tabsList.Add(vAChatTab);
            mainFieldGrid.Children.Add(settingsTab);
            tabsList.Add(settingsTab);
            mainFieldGrid.Children.Add(collapseProgramButton);
            mainFieldGrid.Children.Add(wrapProgramButton);

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

        public ICommand MouseMoveCommand { get; }
        private bool CanMouseMoveCommandExecute(object sender) => true;
        private void OnMouseMoveCommandExecuted(object sender)
        {
            DragMove();
        }

        private void ChangeTextRequest(string text)
        {
            Dispatcher.Invoke(() => title.Text = text);
        }
    }
}
