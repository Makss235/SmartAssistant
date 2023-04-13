using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets.Base
{
    public class BackgroundBorder : Border
    {
        private UIElement uIElement;

        public BackgroundBorder()
        {
            ContentPresenter contentPresenter = new ContentPresenter()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Child = contentPresenter;
            InitializeComponent();
        }

        public BackgroundBorder(UIElement uIElement)
        {
            this.uIElement = uIElement;
            Child = this.uIElement;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            CornerRadius = new CornerRadius(10);
            BorderThickness = new Thickness(3);
            BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
            Background = new SolidColorBrush(Colors.AliceBlue);
 
        }
    }
}
