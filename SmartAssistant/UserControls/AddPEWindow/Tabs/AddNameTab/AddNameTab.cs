using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab
{
    public class AddNameTab : Tab
    {
        private AddPEWindowTabsLoc addPEWindowTabsLoc;
        private Binding enteredNameBinding;

        private TextBlock indicatorNameTextBlock;
        private TextBox enterNameTextBox;
        private TabNavigationButton nextTabButton;
        private RowDefinition tooltipRowDefinition;
        private RowDefinition indicatorRowDefinition;
        private RowDefinition enterRowDefinition;
        private Grid mainGrid;

        public event Action<byte> TabNavigationButtonPressed;
        public event Action<byte, bool> CorrectnessTextChanged;

        #region IsNormalName : bool - Нормальное имя

        /// <summary>Содержаться ли в имени только буквы и цифры</summary>
        private bool _IsNormalName = false;

        /// <summary>Содержаться ли в имени только буквы и цифры</summary>
        public bool IsNormalName
        {
            get => _IsNormalName;
            set => SetProperty(ref _IsNormalName, value);
        }

        #endregion

        #region EnteredName : string - Введенное имя

        /// <summary>Введенное имя</summary>
        private string _EnteredName = string.Empty;

        /// <summary>Введенное имя</summary>
        public string EnteredName
        {
            get => _EnteredName;
            set => SetProperty(ref _EnteredName, value);
        }

        #endregion

        public AddNameTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            PropertyChanged += AddNameTab_PropertyChanged;
            addPEWindowTabsLoc = Localize.JsonObject.AddPEWindowLoc.AddPEWindowTabsLoc;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            indicatorNameTextBlock = new TextBlock()
            {
                Text = addPEWindowTabsLoc.AddNameTabLoc.EnterNameLoc,
                FontSize = 17,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                //ToolTip = new ToolTip() { Content = "Введите название программы\nлатиницей и без спец. символов111" }
            };
            Grid.SetRow(indicatorNameTextBlock, 1);

            enteredNameBinding = new Binding(nameof(EnteredName))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            enterNameTextBox = new TextBox()
            {
                Margin = new Thickness(50, 10, 0, 0),
                BorderThickness = new Thickness(0, 0, 0, 3),
                BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"),
                FontSize = 17,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 350,
                MaxHeight = 45,
                Padding = new Thickness(0, 0, 0, 2),
                VerticalContentAlignment = VerticalAlignment.Bottom,
                TextWrapping = TextWrapping.Wrap,
                Background = ResApp.GetResources<SolidColorBrush>("Transparent"),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            enterNameTextBox.SetBinding(TextBox.TextProperty, enteredNameBinding);
            Grid.SetRow(enterNameTextBox, 2);

            nextTabButton = new TabNavigationButton(addPEWindowTabsLoc.NavigationButtonsLoc.NextButtonLoc, TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            nextTabButton.ButtonPressed += NextTabButton_ButtonPressed;
            Grid.SetRow(nextTabButton, 2);

            tooltipRowDefinition = new RowDefinition()
            { Height = new GridLength(50, GridUnitType.Pixel) };

            indicatorRowDefinition = new RowDefinition()
            { Height = new GridLength(35, GridUnitType.Pixel) };

            enterRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(tooltipRowDefinition);
            mainGrid.RowDefinitions.Add(indicatorRowDefinition);
            mainGrid.RowDefinitions.Add(enterRowDefinition);
            mainGrid.Children.Add(nextTabButton);
            //mainGrid.Children.Add(toolTipGrid);
            mainGrid.Children.Add(indicatorNameTextBlock);
            mainGrid.Children.Add(enterNameTextBox);
            Content = mainGrid;
        }

        private void NextTabButton_ButtonPressed(byte id)
        {
            CheckIsNormalText();
            TabNavigationButtonPressed?.Invoke(id);
        }

        private void AddNameTab_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsNormalName):
                    CheckIsNormalText();
                    break;
                case nameof(EnteredName):
                    EnteredNameChanged();
                    break;
            }
        }

        private void CheckIsNormalText()
        {
            CorrectnessTextChanged?.Invoke(ID, IsNormalName);
        }

        private void EnteredNameChanged()
        {
            if (!Regex.IsMatch(EnteredName.ToLower(), @"^[\w]+$"))
                IsNormalName = false;
            else
                IsNormalName = true;
        }
    }
}
