using SmartAssistant.Infrastructure.Styles.Base.ContextMenuS;
using System.Windows.Controls;
using System.Windows;

namespace SmartAssistant.UserControls.Widgets.SCM
{
    public class SContextMenu : ContextMenu
    {
        public SContextMenu()
        {
            Template = new ContextMenuTemplate();
            ItemContainerStyle = new CommonContextMenuItemStyle(new CornerRadius(5));
            
        }
    }
}
