using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.Infrastructure.Styles.MainWindow
{
    public class MenuButtonStyle : Style
    {
        public MenuButtonStyle()
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(20, 10, 10, 20));

            borderFactory.AppendChild(contentPresenterFactory);

            Trigger trigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            trigger.Setters.Add(new Setter(Control.BackgroundProperty, BasicColors.BackgroundLightBrush));
            trigger.Setters.Add(new Setter(Control.ForegroundProperty, BasicColors.BackgroundDarkBrush));

            Triggers.Add(trigger);
            Setters.Add(new Setter(Control.BackgroundProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(Control.ForegroundProperty, BasicColors.ForegroundWhiteColor));
            Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Bold));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
