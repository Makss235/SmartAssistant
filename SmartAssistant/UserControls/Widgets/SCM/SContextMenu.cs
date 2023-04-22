using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets.SCM
{
    public class SContextMenu : ContextMenu
    {
        public SContextMenu()
        {
            Template = new ContextMenuTemplate();
        }
    }
}
