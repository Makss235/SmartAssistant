using SmartAssistant.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    class ButtonStyled : UserControl
    {
        private Border mainBorder;
        private ContentPresenter mainCP;

        private SolidColorBrush background;
        private FontFamily a = new FontFamily("Times new Roman");
        public CornerRadius CornerRadius { get; set; }
        public ButtonStyled() 
        {
            InitialazeProperties();
            InitialazeComponent();
        }

        private void InitialazeProperties()
        {
            background = Brushes.Green;
            Width = 100;
            Height = 100;
        }

        private void InitialazeComponent()
        {
            MouseEnter += ButtonStyled_MouseEnter;
            mainCP = new ContentPresenter
            {
                Content = "AAA",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                
            };
            mainBorder = new Border
            {
                CornerRadius = new CornerRadius(10),
                Background = background,
                Width = Width,
                Height = Height,
                Child = mainCP
            };
            

            Background = Brushes.Transparent;
            Content = mainBorder;
        }

        private void ButtonStyled_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            background = Brushes.Yellow;
        }
    }
}
