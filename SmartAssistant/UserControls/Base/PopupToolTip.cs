using SmartAssistant.Resources;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace SmartAssistant.UserControls.Base
{
    public class PopupToolTip : Popup, INotifyPropertyChanged
    {
        private DispatcherTimer popupTimer;

        private TextBlock popupTextBlock;
        private Grid mainGrid;
        private Border mainBorder;

        /// <summary>Стартовая позиция</summary>
        public Point StartPoint { get; set; }

        /// <summary>Текст</summary>
        public string Text { get; set; }

        /// <summary>Цвет заднего фона</summary>
        public SolidColorBrush Background { get; set; }

        /// <summary>Цвет текста</summary>
        public SolidColorBrush Foreground { get; set; }

        /// <summary>Цвет границы</summary>
        public SolidColorBrush BorderBrush { get; set; }

        /// <summary>Размер границы</summary>
        public Thickness BorderThickness { get; set; }

        /// <summary>Шрифт</summary>
        public FontFamily FontFamily { get; set; }

        /// <summary>Размер шрифта</summary>
        public double FontSize { get; set; }

        /// <summary>Отступ текста от границ</summary>
        public Thickness Padding { get; set; }

        /// <summary>Расположение текста по вертикали</summary>
        public VerticalAlignment VerticalContentAlignment { get; set; }

        /// <summary>Расположение текста по горизонтали</summary>
        public HorizontalAlignment HorizontalContentAlignment { get; set; }

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

        public PopupToolTip(Point point, string text)
        {
            StartPoint = point;
            Text = text;
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

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AllowsTransparency = true;
            PlacementRectangle = new Rect(StartPoint.X, StartPoint.Y, 0, 0);

            popupTextBlock = new TextBlock()
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
                MaxWidth = 300
            };

            mainGrid = new Grid();
            mainGrid.Children.Add(popupTextBlock);

            mainBorder = new Border()
            {
                Background = Background,
                BorderBrush = BorderBrush,
                BorderThickness = BorderThickness,
                CornerRadius = CornerRadius,
            };
            mainBorder.Child = mainGrid;

            Child = mainBorder;
        }

        public void Show(double milliseconds)
        {
            IsOpen = true;

            popupTimer = new DispatcherTimer(DispatcherPriority.Normal);
            popupTimer.Interval = TimeSpan.FromMilliseconds(milliseconds);
            popupTimer.Tick += (obj, e) =>
            {
                IsOpen = false;
            };
            popupTimer.Start();
        }

        public void Close()
        {
            IsOpen = false;
        }
    }
}
