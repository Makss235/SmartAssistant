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
            SolidColorBrush background,
            SolidColorBrush borderBrush,
            SolidColorBrush mouseOverBackground,
            SolidColorBrush mouseOverBorderBrush,
            //SolidColorBrush ISISAFBackground,
            //SolidColorBrush ISISAFBorderBrush,
            SolidColorBrush ISISATBackground,
            SolidColorBrush ISISATBorderBrush)
        {
            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterF.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterF.SetValue(UIElement.SnapsToDevicePixelsProperty, true);
            contentPresenterF.SetValue(FrameworkElement.MarginProperty, new Thickness(4, 1, 4, 1));

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

            borderF.AppendChild(contentPresenterF);

            Trigger mouseOverT = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(Control.BackgroundProperty, mouseOverBackground));
            mouseOverT.Setters.Add(new Setter(Control.BorderBrushProperty, mouseOverBorderBrush));

            //MultiTrigger ISISAFT = new MultiTrigger
            //{
            //    Conditions =
            //    {
            //        new Condition
            //        { Property = Selector.IsSelectionActiveProperty, Value = false },
            //        new Condition
            //        { Property = ListBoxItem.IsSelectedProperty, Value = true }
            //    },
            //    Setters =
            //    {
            //        new Setter
            //        { Property = ListBoxItem.BackgroundProperty, Value = ISISAFBackground },
            //        new Setter
            //        { Property = ListBoxItem.BorderBrushProperty, Value = ISISAFBorderBrush }
            //    }
            //};

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
            ////Triggers.Add(ISISAFT);
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
