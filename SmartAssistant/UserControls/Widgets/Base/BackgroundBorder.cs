using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets.Base
{
    public class BackgroundBorder : Border
    {
        public BackgroundBorder()
        {
            InitializeComponent();
        }

        public BackgroundBorder(UIElement uIElement)
        {
            Child = uIElement;
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
