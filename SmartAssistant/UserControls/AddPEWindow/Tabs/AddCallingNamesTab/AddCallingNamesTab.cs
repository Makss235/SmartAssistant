using SmartAssistant.UserControls.Base;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab
{
    public class AddCallingNamesTab : Tab, INotifyCollectionChanged
    {
        private ListBox ListBox;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public ObservableCollection<string> CallingNames;

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
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            CallingNames = new ObservableCollection<string>();
            PropertyChanged += AddCallingNamesTab_PropertyChanged;
            CollectionChanged += AddCallingNamesTab_CollectionChanged;

            Grid mainGrid = new Grid();

            ColumnDefinition headingMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(200, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);

            ColumnDefinition headingMenuColumnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(300, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition1);

            ListBox = new ListBox()
            {
                Margin = new Thickness(20, 10, 10, 28),
                ItemsSource = CallingNames
            };
            Grid.SetColumn(ListBox, 0);

            Grid grid = new Grid();
            Grid.SetColumn(grid, 1);

            RowDefinition menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };
            grid.RowDefinitions.Add(menuButtonsRowDefinition);

            RowDefinition mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };
            grid.RowDefinitions.Add(mainFieldRowDefinition);

            TextBlock textBlock = new TextBlock()
            {
                Text = "Введите, как будете\nзвать программу:",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 20, 0),
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            Grid.SetRow(textBlock, 0);
            grid.Children.Add(textBlock);
            
            Binding enteredCallingNameBinding = new Binding(nameof(EnteredCallingName))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            TextBox textBox2 = new TextBox()
            {
                // TODO: Makss привязка ширины к глобальной
                Margin = new Thickness(10, 5, 20, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 260,
                VerticalContentAlignment = VerticalAlignment.Center,
                Height = 60,
                Padding = new Thickness(0, 0, 60, 0),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 15, 
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            textBox2.SetBinding(TextBox.TextProperty, enteredCallingNameBinding);
            Grid.SetRow(textBox2, 1);
            grid.Children.Add(textBox2);

            Button button = new Button()
            {
                Content = "+",
                Margin = new Thickness(10, 5, 28, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 60,
                Height = 60,
                Background = Application.Current.Resources["Transparent"] as SolidColorBrush,
                BorderThickness = new Thickness(0)
            };
            button.Click += Button_Click;
            Panel.SetZIndex(button, 10);
            Grid.SetRow(button, 1);
            grid.Children.Add(button);

            TabNavigationButton previousTabButton =
            new TabNavigationButton("Назад", NavigateButton.TypeButton.Previous, ID)
            {
                Margin = new Thickness(10, 0, 0, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(previousTabButton, 1);
            grid.Children.Add(previousTabButton);

            TabNavigationButton nextTabButton =
            new TabNavigationButton("Далее", NavigateButton.TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetRow(nextTabButton, 1);
            grid.Children.Add(nextTabButton);

            mainGrid.Children.Add(ListBox);
            mainGrid.Children.Add(grid);
            Content = mainGrid;
        }

        private void AddCallingNamesTab_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var enteredCallingNameArray = new string[1] { EnteredCallingName };
            if (enteredCallingNameArray.Intersect(CallingNames.ToList()).ToArray().Count() == 0 
                && EnteredCallingName.Count() != 0)
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
            // TODO: Veser изменение цвета
            if (IsNormalCallingName)
            {

            }
            else
            {
                MessageBox.Show("incorrect");
            }
        }

        private void EnteredCallingNameChanged()
        {
            var enteredCallingNameArray = new string[1] { EnteredCallingName };
            if (enteredCallingNameArray.Intersect(CallingNames.ToList()).Count() == 0)
            {
                IsNormalCallingName = true;
                //MessageBox.Show("true");
            }
            else
            {
                IsNormalCallingName = false;
                //MessageBox.Show("false");
            }
        }
    }
}
