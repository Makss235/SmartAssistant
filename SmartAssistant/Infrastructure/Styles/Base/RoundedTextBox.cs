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
    public class RoundedTextBox : Style
    {
        public RoundedTextBox(
            double fontSize,
            CornerRadius cornerRadius,
            Thickness borderThickness,
            Thickness padding,
            SolidColorBrush background,
            SolidColorBrush borderBrush,
            SolidColorBrush mouseOverBackground,
            SolidColorBrush mouseOverBorderBrush)
        {
            FrameworkElementFactory textBoxF = new FrameworkElementFactory(typeof(TextBox));
            textBoxF.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            textBoxF.SetValue(Control.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            textBoxF.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textBoxF.SetValue(Control.PaddingProperty, padding);
            textBoxF.SetValue(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            textBoxF.SetValue(Control.FontSizeProperty, fontSize);
            textBoxF.SetValue(Control.FontFamilyProperty, new FontFamily("Segoe UI Semibold"));
            textBoxF.SetBinding(TextBox.TextProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Path = new PropertyPath("Text")
            });
            textBoxF.SetBinding(TextBox.MarginProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BackgroundProperty, background);
            borderF.SetValue(Border.BorderThicknessProperty, borderThickness);
            //borderF.SetValue(Border.HeightProperty, (double)50);
            //borderF.SetValue(Border.WidthProperty, (double)Width - 120);
            borderF.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(FrameworkElement.HeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Height")
            });
            borderF.SetBinding(FrameworkElement.MinHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinHeight")
            });
            borderF.SetBinding(FrameworkElement.MaxHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MaxHeight")
            });

            borderF.AppendChild(textBoxF);

            Trigger mouseOverT = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(Control.BackgroundProperty, mouseOverBackground));
            mouseOverT.Setters.Add(new Setter(Control.BorderBrushProperty, mouseOverBorderBrush));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(Control.BorderBrushProperty, borderBrush));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(TextBox))
            {
                VisualTree = borderF
            }));
        }
    }
}
