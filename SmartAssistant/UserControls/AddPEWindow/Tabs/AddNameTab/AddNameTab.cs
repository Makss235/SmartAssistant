using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.Widgets;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab
{
    public class AddNameTab : Tab
    {
        private AddPEWindowTabsLoc addPEWindowTabsLoc;
        private Binding enteredNameBinding;

        private ToolTipText enterNameToolTip;
        private DispatcherTimer enterNameTTShowTimer;

        private TextBlock indicatorNameTextBlock;
        private TextBox enterNameTextBox;
        private TabNavigationButton nextTabButton;
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
            enterNameToolTip = new ToolTipText(new Point(0, 0), 
                "Введите название программы латиницей и без спец. символов") 
            { Placement = PlacementMode.MousePoint };

            indicatorNameTextBlock = new TextBlock()
            {
                Text = addPEWindowTabsLoc.AddNameTabLoc.EnterNameLoc,
                FontSize = 17,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
            };
            indicatorNameTextBlock.MouseEnter += EnterName_MouseEnter;
            indicatorNameTextBlock.MouseLeave += EnterName_MouseLeave;
            Grid.SetRow(indicatorNameTextBlock, 0);

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
            enterNameTextBox.MouseEnter += EnterName_MouseEnter;
            enterNameTextBox.MouseLeave += EnterName_MouseLeave;
            Grid.SetRow(enterNameTextBox, 1);

            nextTabButton = new TabNavigationButton(addPEWindowTabsLoc.NavigationButtonsLoc.NextButtonLoc, TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            nextTabButton.ButtonPressed += NextTabButton_ButtonPressed;
            Grid.SetRow(nextTabButton, 1);

            indicatorRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            enterRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(indicatorRowDefinition);
            mainGrid.RowDefinitions.Add(enterRowDefinition);
            mainGrid.Children.Add(nextTabButton);
            mainGrid.Children.Add(indicatorNameTextBlock);
            mainGrid.Children.Add(enterNameTextBox);
            Content = mainGrid;
        }

        private void EnterName_MouseLeave(object sender, MouseEventArgs e)
        {
            enterNameToolTip.Close();
            if (enterNameTTShowTimer != null) enterNameTTShowTimer.Stop();
        }

        private void EnterName_MouseEnter(object sender, MouseEventArgs e)
        {
            enterNameTTShowTimer = new DispatcherTimer(DispatcherPriority.Normal);
            enterNameTTShowTimer.Interval = TimeSpan.FromMilliseconds(1000);
            enterNameTTShowTimer.Tick += (obj, e) =>
            {
                enterNameToolTip.Show();
            };
            enterNameTTShowTimer.Start();
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
