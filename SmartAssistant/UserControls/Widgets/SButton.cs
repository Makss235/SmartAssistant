using SmartAssistant.UserControls.Widgets.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class SButton : ButtonBase, INotifyPropertyChanged
    {
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

        private UIElement _ButtonContent;

        public UIElement ButtonContent { get { return _ButtonContent; } set { _ButtonContent = value; BackgroundBorder.Child = _ButtonContent; } }
        public BackgroundBorder BackgroundBorder { get; set; }

        public SButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            BackgroundBorder = new BackgroundBorder(ButtonContent);
            ButtonContent = new TextBlock() { Text = "hhh" };

            Background = new SolidColorBrush(Colors.Transparent);
            BorderThickness = new Thickness(0);

            Width = 100;
            Height = 100;

            Content = BackgroundBorder;
        }
    }
}
