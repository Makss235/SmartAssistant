using SmartAssistant.UserControls.Widgets.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        #region ButtonContent : UIElement - Контент кнопки

        /// <summary>Контент кнопки</summary>
        private UIElement _ButtonContent;

        /// <summary>Контент кнопки</summary>
        public UIElement ButtonContent
        {
            get => _ButtonContent;
            set => SetProperty(ref _ButtonContent, value);
        }

        #endregion

        public BackgroundBorder BackgroundBorder { get; set; }

        public SButton()
        {
            PropertyChanged += SButton_PropertyChanged;
            InitializeComponent();
        }

        private void SButton_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(BackgroundBorder):
                    BackgroundBorder_PropertyChanged();
                    break;
                case nameof(ButtonContent):
                    ButtonContent_PropertyChanged();
                    break;
                default:
                    break;
            }
        }

        private void ButtonContent_PropertyChanged()
        {
            BackgroundBorder.Child = ButtonContent;
        }

        private void BackgroundBorder_PropertyChanged()
        {

        }

        private void InitializeComponent()
        {
            BackgroundBorder = new BackgroundBorder(ButtonContent);
            ButtonContent = new TextBlock() 
            { 
                Text = "Button",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 15
            };

            //Width = 150;
            //Height = 50;

            Content = BackgroundBorder;
        }
    }
}
