using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class TransparentButton : ButtonBase
    {
        public TransparentButton()
        {
            Content = new Border()
            { Background = new SolidColorBrush(Colors.Transparent) };
        }
    }
}
