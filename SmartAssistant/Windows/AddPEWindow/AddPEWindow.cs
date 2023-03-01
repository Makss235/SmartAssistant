﻿using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.Windows.AddPEWindow
{
    public partial class AddPEWindow : Window
    {
        private InputBinding mouseMoveIB;
        private DropShadowEffect dropShadowEffect;

        private RowDefinition menuButtonsRowDefinition;
        private RowDefinition mainFieldRowDefinition;
        private Button collapseWindowButton;
        private Grid mainGrid;
        private Border mainBorder;

        public AddPEWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Width = 550;
            Height = 400;
            Title = Localize.JsonObject.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 5,
                BlurRadius = 20,
                Opacity = 0.65
            };
            Effect = dropShadowEffect;

            menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(90, GridUnitType.Pixel) };

            mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(260, GridUnitType.Pixel) };

            Grid.SetRow(ICAddPEButtonsRow(), 0);
            Grid.SetRow(ICMainFieldRow(), 1);

            collapseWindowButton = new Button()
            {
                Style = new WarpAndCollapseProgramButtonStyle(new CornerRadius(0, 15, 0, 15), Application.Current.Resources["Red"] as SolidColorBrush),
                Content = "X",
                Margin = new Thickness(0),
                CommandParameter = true,
            };
            collapseWindowButton.Click += CollapseWindowButton_Click;

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(menuButtonsRowDefinition);
            mainGrid.RowDefinitions.Add(mainFieldRowDefinition);
            mainGrid.Children.Add(addPEButtonsStackPanel);
            mainGrid.Children.Add(mainFieldGrid);
            mainGrid.Children.Add(collapseWindowButton);

            mouseMoveIB = new InputBinding(new DragMoveCommand(this), new MouseGesture()
            { MouseAction = MouseAction.LeftClick });

            mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.AliceBlue),
                CornerRadius = new CornerRadius(20, 20, 20, 20),
                BorderThickness = new Thickness(4),
                BorderBrush = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush,
                Width = 500,
                Height = 350
            };
            mainBorder.InputBindings.Add(mouseMoveIB);
            mainBorder.Child = mainGrid;

            Content = mainBorder;
        }

        private void CollapseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
