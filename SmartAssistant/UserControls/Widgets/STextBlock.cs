using SmartAssistant.Resources;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class STextBlock : UserControl, INotifyPropertyChanged
    {
        private Binding textBinding;
        //private Binding maxWidthBinding;

        private TextBlock mainTextBlock;
        private Border mainBorder;

        #region Text : string - Текст

        /// <summary>Текст</summary>
        private string _Text;

        /// <summary>Текст</summary>
        public string Text
        {
            get => _Text;
            set => SetProperty(ref _Text, value);
        }

        #endregion

        #region MaxWidth : string - Максимальная ширина текста

        /// <summary>Максимальная ширина текста</summary>
        private double _MaxWidth;

        /// <summary>Максимальная ширина текста</summary>
        public double MaxWidth
        {
            get => _MaxWidth;
            set => SetProperty(ref _MaxWidth, value);
        }

        #endregion

        /// <summary>Закругление углов</summary>
        public CornerRadius CornerRadius { get; set; }

        #region NPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            //if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        public STextBlock(string text = "", double maxWidth = 300)
        {
            Text = text;
            MaxWidth = maxWidth;

            InitializeProperties();
            InitializeComponent();
        }

        private void InitializeProperties()
        {
            Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush");
            Foreground = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
            BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
            BorderThickness = new Thickness(1);
            FontFamily = new FontFamily("Segoe UI Semibold");
            FontSize = 15;
            Padding = new Thickness(13, 7, 13, 7);
            VerticalContentAlignment = VerticalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Left;
            CornerRadius = new CornerRadius(5);
        }

        private void InitializeComponent()
        {
            textBinding = new Binding(nameof(Text))
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = this
            };

            //maxWidthBinding = new Binding(nameof(MaxWidth))
            //{
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            //    Mode = BindingMode.OneWay,
            //    Source = this
            //};

            mainTextBlock = new TextBlock()
            {
                Text = Text,
                Foreground = Foreground,
                Background = Brushes.Transparent,
                FontSize = FontSize,
                FontFamily = FontFamily,
                Margin = Padding,
                VerticalAlignment = VerticalContentAlignment,
                HorizontalAlignment = HorizontalContentAlignment,
                TextWrapping = TextWrapping.Wrap,
                MaxWidth = MaxWidth
            };
            mainTextBlock.SetBinding(TextBlock.TextProperty, textBinding);
            //mainTextBlock.SetBinding(MaxWidthProperty, maxWidthBinding);

            mainBorder = new Border()
            {
                Background = Background,
                BorderBrush = BorderBrush,
                BorderThickness = BorderThickness,
                CornerRadius = CornerRadius
            };
            mainBorder.Child = mainTextBlock;

            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);
            Padding = new Thickness(0);

            Content = mainBorder;
        }
    }
}
