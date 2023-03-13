﻿using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
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
        private AddPEWindowTabsLoc addPEWindowTabsLoc;

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
        public event Action<byte, bool> CorrectnessTextChanged;

        #region IsNormalPath : bool - Нормальный путь

        /// <summary>Не пуста ли строка</summary>
        private bool _IsNormalPath = false;

        /// <summary>Не пуста ли строка</summary>
        public bool IsNormalPath
        {
            get => _IsNormalPath;
            set => SetProperty(ref _IsNormalPath, value);
        }

        #endregion

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
            PropertyChanged += AddPathTab_PropertyChanged;
            addPEWindowTabsLoc = Localize.JsonObject.AddPEWindowLoc.AddPEWindowTabsLoc;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            indicatorPathTextBlock = new TextBlock()
            {
                Text = addPEWindowTabsLoc.AddPathTabLoc.EnterPathLoc,
                FontSize = 17,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                //ToolTip = new ToolTip() { Content = "Введите абсолютный путь\nдо exe-файла программы111" }
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
                BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"),
                FontSize = 17,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 350,
                MaxHeight = 60,
                Padding = new Thickness(0, 0, 0, 2),
                VerticalContentAlignment = VerticalAlignment.Bottom,
                TextWrapping = TextWrapping.Wrap,
                Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            enterPathTextBox.SetBinding(TextBox.TextProperty, enteredPathBinding);
            Grid.SetRow(enterPathTextBox, 1);

            previousTabButton = new TabNavigationButton(addPEWindowTabsLoc.NavigationButtonsLoc.PreviousButtonLoc, TypeButton.Previous, ID)
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
                FontSize = 15,
                Content = addPEWindowTabsLoc.NavigationButtonsLoc.DoneButtonLoc,
                Style = new RoundedButton(
                    new CornerRadius(10),
                    new Thickness(1),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"))
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
            CheckIsNormalText();
            TabNavigationButtonPressed?.Invoke(id);
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIsNormalText();
            DoneButtonPressed?.Invoke();
        }

        private void AddPathTab_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsNormalPath):
                    CheckIsNormalText();
                    break;
                case nameof(EnteredPath):
                    EnteredPathChanged();
                    break;
            }
        }

        private void CheckIsNormalText()
        {
            CorrectnessTextChanged?.Invoke(ID, IsNormalPath);
        }

        private void EnteredPathChanged()
        {
            if (string.IsNullOrEmpty(EnteredPath))
            {
                IsNormalPath = false;
            }
            else
            {
                IsNormalPath = true;
            }
        }
    }
}
