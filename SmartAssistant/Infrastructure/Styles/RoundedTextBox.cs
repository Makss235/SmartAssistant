using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles
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
            textBoxF.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textBoxF.SetValue(TextBox.BackgroundProperty, Application.Current.Resources["Transparent"]);
            textBoxF.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textBoxF.SetValue(TextBox.PaddingProperty, padding);
            textBoxF.SetValue(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            textBoxF.SetValue(TextBox.FontSizeProperty, fontSize);
            textBoxF.SetValue(TextBox.FontFamilyProperty, new FontFamily("Segoe UI Semibold"));
            textBoxF.SetBinding(TextBox.TextProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Text")
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
            borderF.SetBinding(Border.HeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Height")
            });
            borderF.SetBinding(Border.MinHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinHeight")
            });
            borderF.SetBinding(Border.MaxHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MaxHeight")
            });

            borderF.AppendChild(textBoxF);

            Trigger mouseOverT = new Trigger
            {
                Property = TextBox.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(TextBox.BackgroundProperty, mouseOverBackground));
            mouseOverT.Setters.Add(new Setter(TextBox.BorderBrushProperty, mouseOverBorderBrush));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(Control.BorderBrushProperty, borderBrush));
            //Setters.Add(new Setter(Control.MinHeightProperty, (double)50));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(TextBox))
            {
                VisualTree = borderF
            }));
        }
    }
}
