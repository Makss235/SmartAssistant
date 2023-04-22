using SmartAssistant.UserControls.Widgets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets.SCM
{
    public class ContextMenuTemplate : ControlTemplate
    {
        public ContextMenuTemplate()
        {
            FrameworkElementFactory itemsPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));

            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(BackgroundBorder));
            factory.SetValue(Border.WidthProperty, (double)200);
            factory.SetValue(Border.HeightProperty, (double)200);

            factory.AppendChild(itemsPresenterF);

            VisualTree = factory;
        }
    }
}
