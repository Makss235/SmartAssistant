using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab
{
    public class AddCallingNamesTab : Tab
    {
        private AddPEWindowTabsLoc addPEWindowTabsLoc;

        private Binding enteredCallingNameBinding;

        private ListBox addCaliingNamesListBox;
        private TextBlock indicatorCallingNameTextBlock;
        private TextBox enterCallingNameTextBox;
        private Button addCallingNameButton;
        private TabNavigationButton previousTabButton;
        private TabNavigationButton nextTabButton;
        private RowDefinition indicatorRowDefinition;
        private RowDefinition enterRowDefinition;
        private Grid addCallingNameGrid;
        private ColumnDefinition listBoxColumnDefinition;
        private ColumnDefinition addCallingNameColumnDefinition;
        private Grid mainGrid;

        public event Action<byte> TabNavigationButtonPressed;
        public event Action<bool> CorrectnessTextChanged;

        public ObservableCollection<string> CallingNames { get; set; }

        #region IsNormalCallingName : bool - Нормальное называемое имя

        /// <summary>Содержаться ли в называемом имени только буквы и цифры</summary>
        private bool _IsNormalCallingName;

        /// <summary>Содержаться ли в называемом имени только буквы и цифры</summary>
        public bool IsNormalCallingName
        {
            get => _IsNormalCallingName;
            set => SetProperty(ref _IsNormalCallingName, value);
        }

        #endregion

        #region EnteredCallingName : string - Введенное называемое имя

        /// <summary>Введенное называемое имя</summary>
        private string _EnteredCallingName;

        /// <summary>Введенное называемое имя</summary>
        public string EnteredCallingName
        {
            get => _EnteredCallingName;
            set => SetProperty(ref _EnteredCallingName, value);
        }

        #endregion

        public AddCallingNamesTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            CallingNames = new ObservableCollection<string>();
            PropertyChanged += AddCallingNamesTab_PropertyChanged;
            addPEWindowTabsLoc = Localize.JsonObject.AddPEWindowLoc.AddPEWindowTabsLoc;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            addCaliingNamesListBox = new ListBox()
            {
                Margin = new Thickness(20, 10, 10, 28),
                ItemsSource = CallingNames,
                Style = new CommonListBoxStyle(
                    new CornerRadius(10),
                    new Thickness(2),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")
                    ),
                ItemContainerStyle = new CommonListBoxItemStyle(
                    new CornerRadius(10),
                    new Thickness(2),
                    ResApp.GetResources<SolidColorBrush>("Black"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("FadedDarkBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("FadedDarkBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent")
                    )
            };
            Grid.SetColumn(addCaliingNamesListBox, 0);

            indicatorCallingNameTextBlock = new TextBlock()
            {
                Text = addPEWindowTabsLoc.AddCallingNamesTabLoc.EnterCallingNameLoc,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 20, 0),
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 200,
                TextWrapping = TextWrapping.Wrap
            };
            Grid.SetRow(indicatorCallingNameTextBlock, 0);

            enteredCallingNameBinding = new Binding(nameof(EnteredCallingName))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            enterCallingNameTextBox = new TextBox()
            {
                // TODO: Makss привязка ширины к глобальной
                Margin = new Thickness(10, 5, 20, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 260,
                Height = 60,
                Padding = new Thickness(10, 0, -25, 0),
                Style = new RoundedTextBox(
                    15,
                    new CornerRadius(20),
                    new Thickness(2),
                    new Thickness(0, 0, 60, 0),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"))
            };
            enterCallingNameTextBox.SetBinding(TextBox.TextProperty, enteredCallingNameBinding);
            Grid.SetRow(enterCallingNameTextBox, 1);

            addCallingNameButton = new Button()
            {
                Content = "+",
                FontSize = 30,
                Padding = new Thickness(0, 0, 0, 8),
                Margin = new Thickness(10, 5, 28, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 60,
                Height = 60,
                Style = new RoundedButton(
                    new CornerRadius(0, 20, 20, 0),
                    new Thickness(0),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush")),
            };
            addCallingNameButton.Click += AddCallingNameButton_Click;
            Panel.SetZIndex(addCallingNameButton, 10);
            Grid.SetRow(addCallingNameButton, 1);

            previousTabButton = new TabNavigationButton(addPEWindowTabsLoc.NavigationButtonsLoc.PreviousButtonLoc, TypeButton.Previous, ID)
            {
                Margin = new Thickness(10, 0, 0, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            previousTabButton.ButtonPressed += NavigationButtonPressed;
            Grid.SetRow(previousTabButton, 1);

            nextTabButton = new TabNavigationButton(addPEWindowTabsLoc.NavigationButtonsLoc.NextButtonLoc, TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            nextTabButton.ButtonPressed += NavigationButtonPressed;
            Grid.SetRow(nextTabButton, 1);

            indicatorRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            enterRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };

            addCallingNameGrid = new Grid();
            Grid.SetColumn(addCallingNameGrid, 1);
            addCallingNameGrid.RowDefinitions.Add(indicatorRowDefinition);
            addCallingNameGrid.RowDefinitions.Add(enterRowDefinition);
            addCallingNameGrid.Children.Add(indicatorCallingNameTextBlock);
            addCallingNameGrid.Children.Add(enterCallingNameTextBox);
            addCallingNameGrid.Children.Add(addCallingNameButton);
            addCallingNameGrid.Children.Add(previousTabButton);
            addCallingNameGrid.Children.Add(nextTabButton);

            listBoxColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(200, GridUnitType.Pixel) };

            addCallingNameColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(300, GridUnitType.Pixel) };

            mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(listBoxColumnDefinition);
            mainGrid.ColumnDefinitions.Add(addCallingNameColumnDefinition);
            mainGrid.Children.Add(addCaliingNamesListBox);
            mainGrid.Children.Add(addCallingNameGrid);
            Content = mainGrid;
        }

        private void NavigationButtonPressed(byte id)
        {
            TabNavigationButtonPressed?.Invoke(id);
        }

        private void AddCallingNameButton_Click(object sender, RoutedEventArgs e)
        {
            var enteredCallingNameArray = new string[1] { EnteredCallingName };
            if (enteredCallingNameArray.Intersect(CallingNames.ToList()).ToArray().Count() == 0 
                && !Equals(EnteredCallingName, string.IsNullOrEmpty))
            {
                Application.Current.Dispatcher.Invoke(() => 
                    CallingNames.Add(EnteredCallingName));
                EnteredCallingName = string.Empty;
            }
        }

        private void AddCallingNamesTab_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsNormalCallingName):
                    CheckIsNormalText();
                    break;
                case nameof(EnteredCallingName):
                    EnteredCallingNameChanged();
                    break;
            }
        }

        private void CheckIsNormalText()
        {
            CorrectnessTextChanged?.Invoke(IsNormalCallingName);
        }

        private void EnteredCallingNameChanged()
        {
            var enteredCallingNameArray = new string[1] { EnteredCallingName };
            if (enteredCallingNameArray.Intersect(CallingNames.ToList()).Count() == 0)
            {
                IsNormalCallingName = true;
            }
            else
            {
                IsNormalCallingName = false;
            }
        }
    }
}
