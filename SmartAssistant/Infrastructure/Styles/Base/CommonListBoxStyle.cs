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
    public class CommonListBoxStyle : Style
    {
        public CommonListBoxStyle(CornerRadius cornerRadius, Thickness borderThickness, SolidColorBrush background, SolidColorBrush borderBrush)
        {
            FrameworkElementFactory itemPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemPresenterF.SetValue(UIElement.SnapsToDevicePixelsProperty, true);

            FrameworkElementFactory scrollViewerF = new FrameworkElementFactory(typeof(ScrollViewer));
            scrollViewerF.SetValue(Control.PaddingProperty, new Thickness(1));
            scrollViewerF.SetValue(UIElement.FocusableProperty, true);
            scrollViewerF.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            scrollViewerF.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollViewerF.SetValue(ScrollViewer.PanningModeProperty, PanningMode.Both);

            scrollViewerF.AppendChild(itemPresenterF);

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderF.SetValue(Border.BackgroundProperty, background);
            borderF.SetValue(Border.BorderBrushProperty, borderBrush);
            borderF.SetValue(Border.BorderThicknessProperty, borderThickness);
            borderF.SetValue(Border.PaddingProperty, new Thickness(1));
            borderF.SetValue(UIElement.SnapsToDevicePixelsProperty, true);

            borderF.AppendChild(scrollViewerF);

            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(ListBox))
            {
                VisualTree = borderF
            }));
        }
    }
}
