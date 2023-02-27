﻿using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.UserControls.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddPathTab
{
    public class AddPathTab : Tab
    {
        private Binding enteredPathBinding;

        private TextBlock indicatorPathTextBlock;
        private TextBox enterPathTextBox;
        private TabNavigationButton previousTabButton;
        private Button doneButton;
        private RowDefinition indicatorRowDefinition;
        private RowDefinition enterRowDefinition;
        private Grid mainGrid;

        public event Action<byte> TabNavigationButtonPressed;
        public event Action DoneButtonPressed;

        #region EnteredPath : string - Введенный путь

        /// <summary>Введенный путь</summary>
        private string _EnteredPath = string.Empty;

        /// <summary>Введенный путь</summary>
        public string EnteredPath
        {
            get => _EnteredPath;
            set => SetProperty(ref _EnteredPath, value);
        }

        #endregion

        public AddPathTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // TODO: Makss localize
            indicatorPathTextBlock = new TextBlock()
            {
                Text = "Путь программы:",
                FontSize = 15,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                ToolTip = new ToolTip() { Content = "Введите абсолютный путь\nдо exe-файла программы" }
            };
            Grid.SetRow(indicatorPathTextBlock, 0);

            enteredPathBinding = new Binding(nameof(EnteredPath))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            enterPathTextBox = new TextBox()
            {
                Margin = new Thickness(50, 10, 0, 0),
                BorderThickness = new Thickness(0, 0, 0, 3),
                BorderBrush = Application.Current.Resources["BackgroundDarkBrush"] as SolidColorBrush,
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 300,
                MaxHeight = 60,
                Padding = new Thickness(0, 0, 0, 2),
                VerticalContentAlignment = VerticalAlignment.Bottom,
                TextWrapping = TextWrapping.Wrap,
                Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            enterPathTextBox.SetBinding(TextBox.TextProperty, enteredPathBinding);
            Grid.SetRow(enterPathTextBox, 1);

            previousTabButton = new TabNavigationButton("Назад", TypeButton.Previous, ID)
            {
                Margin = new Thickness(20, 0, 0, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            previousTabButton.ButtonPressed += PreviousTabButton_ButtonPressed;
            Grid.SetRow(previousTabButton, 1);


            doneButton = new Button()
            {
                Width = 80,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(10, 5, 28, 28),
                HorizontalAlignment = HorizontalAlignment.Right,
                Content = "Готово",
                Style = new RoundedButton(
                    new CornerRadius(10),
                    new Thickness(1),
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"])
            };
            doneButton.Click += DoneButton_Click;
            Grid.SetRow(doneButton, 1);

            indicatorRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            enterRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(indicatorRowDefinition);
            mainGrid.RowDefinitions.Add(enterRowDefinition);
            mainGrid.Children.Add(indicatorPathTextBlock);
            mainGrid.Children.Add(enterPathTextBox);
            mainGrid.Children.Add(previousTabButton);
            mainGrid.Children.Add(doneButton);

            Content = mainGrid;
        }

        private void PreviousTabButton_ButtonPressed(byte id)
        {
            TabNavigationButtonPressed?.Invoke(id);
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            DoneButtonPressed?.Invoke();
        }
    }
}
