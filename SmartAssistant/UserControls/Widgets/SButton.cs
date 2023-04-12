using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace SmartAssistant.UserControls.Widgets
{
    public class SButton : UserControl, INotifyPropertyChanged
    {
        private ContentPresenter buttonContent;
        private Border mainBorder;

        //Свойства для кнопки и бордера (Можно определять как обычные свойства при создании объекта класса)
        #region ButContent

        private string butContent;
        public string ButContent
        {
            get => butContent;
            set => SetProperty(ref butContent, value);
        }

        #endregion

        #region ButBackground

        private SolidColorBrush butBackground;

        public SolidColorBrush ButBackground
        {
            get => butBackground;
            set => SetProperty(ref butBackground, value);
        }

        #endregion

        #region ButCornerRadius

        private CornerRadius butCornerRadius;

        public CornerRadius ButCornerRadius
        {
            get => butCornerRadius;
            set => SetProperty(ref butCornerRadius, value);
        }

        #endregion

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

        public SButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            buttonContent = new ContentPresenter
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            //Биндинг к контенту у кнопки
            buttonContent.SetBinding(Button.ContentProperty, new Binding("ButContent") { Source = this } );

            mainBorder = new Border
            {
                Width = Width,
                Height = Height,
                Child = buttonContent,
            };
            //Аналогичный биндинг для заднего фона, но уже у бордера
            mainBorder.SetBinding(Border.BackgroundProperty, new Binding("ButBackground") { Source = this } );
            //Аналогичный биндинг для скругления углов
            mainBorder.SetBinding(Border.CornerRadiusProperty, new Binding("ButCornerRadius") { Source = this } );
            mainBorder.MouseEnter += MainBorder_ME;
            mainBorder.MouseLeave += MainBorder_ML;

            Content = mainBorder;
        }
        //Лучше делать обработчики событий там, где создается объект
        private void MainBorder_ME(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("ME");
        }

        private void MainBorder_ML(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("ML");
        }
    }
}
