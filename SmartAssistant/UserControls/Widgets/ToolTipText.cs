using SmartAssistant.Resources;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace SmartAssistant.UserControls.Widgets
{
    public class ToolTipText : ToolTip
    {
        private DispatcherTimer popupTimer;
        private DropShadowEffect dropShadowEffect;

        /// <summary>Стартовая позиция</summary>
        public Point StartPoint { get; set; }

        /// <summary>Текст</summary>
        public string Text { get; set; }

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

        public ToolTipText(Point point, string text, double maxWidth = 300)
        {
            StartPoint = point;
            Text = text;

            PlacementRectangle = new Rect(StartPoint.X, StartPoint.Y, 0, 0);
            Placement = PlacementMode.AbsolutePoint;
            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);

            dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 2,
                BlurRadius = 7,
                Opacity = 0.6
            };
            Effect = dropShadowEffect;

            Content = new TextBlockStyled(Text, maxWidth);
        }

        public void Show(double milliseconds = -1)
        {
            IsOpen = true;

            if (milliseconds > 0)
            {
                popupTimer = new DispatcherTimer(DispatcherPriority.Normal);
                popupTimer.Interval = TimeSpan.FromMilliseconds(milliseconds);
                popupTimer.Tick += (obj, e) =>
                {
                    IsOpen = false;
                };
                popupTimer.Start();
            }
        }

        public void Close()
        {
            IsOpen = false;
            if (popupTimer != null) popupTimer.Stop();
        }
    }
}
