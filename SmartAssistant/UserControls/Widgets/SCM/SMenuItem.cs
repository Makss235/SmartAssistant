using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace SmartAssistant.UserControls.Widgets.SCM
{
    public class SMenuItem : MenuItem
    {
        private ContentPresenter contentPresenter;
        private Border mainBorder;
        public SMenuItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            contentPresenter = new ContentPresenter
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "RRRRR",
            };

            //ItemsPresenter a = new ItemsPresenter();

            mainBorder = new Border
            {
                Child = contentPresenter,
                Background = Brushes.Transparent,
                Width = 200,
                //Height = 50,
                Margin = new Thickness(-20)
            };

            Template = new MenuItemTemplate();
        }
    }
}
