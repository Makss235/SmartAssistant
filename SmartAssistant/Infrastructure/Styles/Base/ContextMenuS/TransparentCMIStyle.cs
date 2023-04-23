using SmartAssistant.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base.ContextMenuS
{
    public class TransparentCMIStyle : Style
    {
        public TransparentCMIStyle() 
        {
            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            borderF.SetValue(Border.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            borderF.AppendChild(contentPresenterF);

            Trigger mouseOverT = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(Control.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent")));
            mouseOverT.Setters.Add(new Setter(Control.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("Transparent")));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(MenuItem))
            {
                VisualTree = borderF
            }));
        }
    }
}
