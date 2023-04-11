using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class SButton : UserControl
    {
        private ContentPresenter buttonContent;
        private Border mainBorder;
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

            mainBorder = new Border
            {
                Background = Brushes.Green,
                Width = Width,
                Height = Height,
                Child = buttonContent,
            };
            mainBorder.MouseEnter += MainBorder_ME;

            Content = mainBorder;
        }

        private void MainBorder_ME(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mainBorder.Background = Brushes.Pink;
        }
    }
}
