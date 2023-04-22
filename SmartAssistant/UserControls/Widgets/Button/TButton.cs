using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets.Button
{
    public class TButton : ButtonBase
    {
        public TButton()
        {
            Content = new Border()
            { Background = new SolidColorBrush(Colors.Transparent) };
        }
    }
}
