using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant
{
    public class WarpAndCollapseProgramButtonStyle : Style
    {
        public WarpAndCollapseProgramButtonStyle(double TopRight, double BottomLeft, double RightMargin, SolidColorBrush TriggerBackGroundColor) 
        {
            const double ButtonWidth = 40;
            const double ButtonHeight = 36;

            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(0, TopRight, 0, BottomLeft));
            borderFactory.SetBinding(Border.BorderThicknessProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderThickness")
            });
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });

            borderFactory.AppendChild(contentPresenterFactory);

            Trigger MouseOverTrigger = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            MouseOverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, TriggerBackGroundColor));

            Triggers.Add(MouseOverTrigger);
            Setters.Add(new Setter(Button.BackgroundProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(Button.WidthProperty, ButtonWidth));
            Setters.Add(new Setter(Button.HeightProperty, ButtonHeight));
            Setters.Add(new Setter(Button.VerticalAlignmentProperty, VerticalAlignment.Top));
            Setters.Add(new Setter(Button.HorizontalAlignmentProperty, HorizontalAlignment.Right));
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(Button.MarginProperty, new Thickness(0, 0, RightMargin, 0)));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
