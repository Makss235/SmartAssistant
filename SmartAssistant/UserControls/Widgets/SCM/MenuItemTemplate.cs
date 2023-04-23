using SmartAssistant.UserControls.Widgets.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.Widgets.SCM
{
    public class MenuItemTemplate : ControlTemplate
    {
        public MenuItemTemplate()
        {
            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterF.SetValue(FrameworkElement.MarginProperty, new Thickness(10, 5, 10, 5));
            contentPresenterF.SetBinding(ContentPresenter.ContentProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Header")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(BackgroundBorder));
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(2));
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));

            borderF.AppendChild(contentPresenterF);

            VisualTree = borderF;
        }
    }
}
