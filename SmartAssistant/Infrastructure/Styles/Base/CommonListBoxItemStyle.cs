using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class CommonListBoxItemStyle : Style
    {
        public CommonListBoxItemStyle(
            CornerRadius cornerRadius,
            Thickness borderThickness,
            SolidColorBrush foreground,
            SolidColorBrush background,
            SolidColorBrush borderBrush,
            SolidColorBrush mouseOverBackground,
            SolidColorBrush mouseOverBorderBrush,
            SolidColorBrush ISISATBackground,
            SolidColorBrush ISISATBorderBrush)
        {

            FrameworkElementFactory textBlockF = new FrameworkElementFactory(typeof(TextBlock));
            textBlockF.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            textBlockF.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBlockF.SetValue(TextBlock.SnapsToDevicePixelsProperty, true);
            textBlockF.SetValue(TextBlock.MarginProperty, new Thickness(4, 1, 4, 1));
            textBlockF.SetValue(TextBlock.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            textBlockF.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            textBlockF.SetValue(TextBlock.ForegroundProperty, foreground);
            textBlockF.SetBinding(TextBlock.TextProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Content")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BorderThicknessProperty, borderThickness);
            borderF.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });

            borderF.AppendChild(textBlockF);

            Trigger mouseOverT = new Trigger
            {
                Property = ListBoxItem.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(Control.BackgroundProperty, mouseOverBackground));
            mouseOverT.Setters.Add(new Setter(Control.BorderBrushProperty, mouseOverBorderBrush));

            MultiTrigger ISISATT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition
                    { Property = Selector.IsSelectionActiveProperty, Value = true },
                    new Condition
                    { Property = ListBoxItem.IsSelectedProperty, Value = true }
                },
                Setters =
                {
                    new Setter
                    { Property = Control.BackgroundProperty, Value = ISISATBackground },
                    new Setter
                    { Property = Control.BorderBrushProperty, Value = ISISATBorderBrush }
                }
            };

            Triggers.Add(mouseOverT);
            Triggers.Add(ISISATT);
            Setters.Add(new Setter(Control.BackgroundProperty, background));
            Setters.Add(new Setter(Control.BorderBrushProperty, borderBrush));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(ListBoxItem))
            {
                VisualTree = borderF
            }));
        }
    }
}
