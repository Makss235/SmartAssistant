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
        #region IsNormalText : bool - Нормальный текст

        /// <summary>Содержаться ли в тексте только буквы и цифры</summary>
        private bool _IsNormalText;

        /// <summary>Содержаться ли в тексте только буквы и цифры</summary>
        public bool IsNormalText
        {
            get => _IsNormalText;
            set => SetProperty(ref _IsNormalText, value);
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
            TextBlock textBlock = new TextBlock()
            {
                Text = "Название программы:",
                FontSize = 15,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                ToolTip = new ToolTip() { Content = "Введите название программы\nлатиницей и без спец. символов" }
            };
            Grid.SetRow(textBlock, 0);

            TextBox typpingNameTextBox = new TextBox()
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
            typpingNameTextBox.TextChanged += TyppingNameTextBox_TextChanged;
            typpingNameTextBox.SetBinding(TextBox.TextProperty, 
                new Binding(nameof(typpingNameTextBox.Text)) 
            { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            Grid.SetRow(typpingNameTextBox, 1);

            TabNavigationButton nextTabButton =
            new TabNavigationButton("Далее", NavigateButton.TypeButton.Next, ID)
            {
                Margin = new Thickness(0, 0, 28, 28),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetRow(nextTabButton, 1);
            mainGrid.Children.Add(nextTabButton);

            mainGrid.Children.Add(textBlock);
            mainGrid.Children.Add(typpingNameTextBox);
            Content = mainGrid;
        }

        private void NextTabButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddNameTab_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsNormalText):
                    CheckIsNormalText();
                    break;
            }
        }

        private void CheckIsNormalText()
        {
            // TODO: Veser изменение цвета
            if (IsNormalText)
            {

            }
            else
            {
                MessageBox.Show("incorrect");
            }
        }

        private void TyppingNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBoxObject = (TextBox)sender;
            if (!Regex.IsMatch(textBoxObject.Text, @"^[a-zA-Z0-9_]+$"))
            {
                IsNormalText = false;
                return;
            }
        }
    }
}
