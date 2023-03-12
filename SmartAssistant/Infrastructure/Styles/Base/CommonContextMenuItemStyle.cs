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

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class CommonContextMenuItemStyle : Style
    {
        public CommonContextMenuItemStyle() 
        {
            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenterF.SetValue(ContentPresenter.MarginProperty, new Thickness(3, 0, 0, 0));
            contentPresenterF.SetBinding(ContentPresenter.ContentProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Header")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetBinding(Border.MinWidthProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinWidth")
            });
            borderF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });

            borderF.AppendChild(contentPresenterF);

            Trigger mouseOverT = new Trigger 
            { 
                Property = MenuItem.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(MenuItem.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            mouseOverT.Setters.Add(new Setter(MenuItem.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(MenuItem.MinWidthProperty, (double)50));
            Setters.Add(new Setter(MenuItem.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("DarkerBrush")));
            Setters.Add(new Setter(MenuItem.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("FadedDarkBrush")));
            Setters.Add(new Setter(MenuItem.TemplateProperty, new ControlTemplate(typeof(MenuItem))
            {
                VisualTree = borderF
            }));

        }
    }
}
