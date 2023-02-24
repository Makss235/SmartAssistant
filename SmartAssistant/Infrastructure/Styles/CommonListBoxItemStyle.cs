using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles
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
            contentPresenterF.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterF.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterF.SetValue(ContentPresenter.SnapsToDevicePixelsProperty, true);
            contentPresenterF.SetValue(ContentPresenter.MarginProperty, new Thickness(4, 1, 4, 1));

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
                Property = ListBoxItem.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(ListBoxItem.BackgroundProperty, mouseOverBackground));
            mouseOverT.Setters.Add(new Setter(ListBoxItem.BorderBrushProperty, mouseOverBorderBrush));

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
                    { Property = ListBoxItem.BackgroundProperty, Value = ISISATBackground },
                    new Setter
                    { Property = ListBoxItem.BorderBrushProperty, Value = ISISATBorderBrush }
                }
            };

            Triggers.Add(mouseOverT);
            ////Triggers.Add(ISISAFT);
            Triggers.Add(ISISATT);
            Setters.Add(new Setter(ListBoxItem.BackgroundProperty, background));
            Setters.Add(new Setter(ListBoxItem.BorderBrushProperty, borderBrush));
            Setters.Add(new Setter(ListBoxItem.TemplateProperty, new ControlTemplate(typeof(ListBoxItem))
            {
                VisualTree = borderF
            }));
        }
    }
}
