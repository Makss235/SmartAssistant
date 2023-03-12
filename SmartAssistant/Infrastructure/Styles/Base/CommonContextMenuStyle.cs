using SmartAssistant.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class CommonContextMenuStyle : Style
    {
        public CommonContextMenuStyle()
        {
            FrameworkElementFactory itemPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemPresenterF.SetValue(ItemsPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            itemPresenterF.SetValue(ItemsPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            itemPresenterF.SetValue(ItemsPresenter.MarginProperty, new Thickness(-0.1, 8, -0.1, 8));

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("FadedDarkBrush"));
            borderF.SetValue(Border.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"));
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));

            borderF.AppendChild(itemPresenterF);

            Setters.Add(new Setter(ContextMenu.TemplateProperty, new ControlTemplate(typeof(ContextMenu))
            {
                VisualTree = borderF
            }));
        }
    }
}
