using SmartAssistant.UserControls.Base;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab
{
    public class AddNameTab : Tab
    {
        #region IsNormalName : bool - Нормальное имя

        /// <summary>Содержаться ли в имени только буквы и цифры</summary>
        private bool _IsNormalName;

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
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            PropertyChanged += AddNameTab_PropertyChanged;

            Grid mainGrid = new Grid();

            RowDefinition menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(menuButtonsRowDefinition);

            RowDefinition mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(mainFieldRowDefinition);

            // TODO: Makss localize
            // TODO: Veser styles
            TextBlock indicatorNameTextBlock = new TextBlock()
            {
                Text = "Название программы:",
                FontSize = 15,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                ToolTip = new ToolTip() { Content = "Введите название программы\nлатиницей и без спец. символов" }
            };
            Grid.SetRow(indicatorNameTextBlock, 0);

            Binding enteredNameBinding = new Binding(nameof(EnteredName))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            TextBox enterNameTextBox = new TextBox()
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
            enterNameTextBox.SetBinding(TextBox.TextProperty, enteredNameBinding);
            Grid.SetRow(enterNameTextBox, 1);

            TabNavigationButton nextTabButton =
            new TabNavigationButton("Далее", NavigateButton.TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetRow(nextTabButton, 1);
            mainGrid.Children.Add(nextTabButton);

            mainGrid.Children.Add(indicatorNameTextBlock);
            mainGrid.Children.Add(enterNameTextBox);
            Content = mainGrid;
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
            // TODO: Veser изменение цвета
            if (IsNormalName)
            {
                //MessageBox.Show("correct");
            }
            else
            {
                MessageBox.Show("incorrect");
            }
        }

        private void EnteredNameChanged()
        {
            if (!Regex.IsMatch(EnteredName, @"^[a-zA-Z0-9_]+$"))
            {
                IsNormalName = false;
                return;
            }
            else
            {
                IsNormalName = true;
            }
        }
    }
}
