using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant
{
    public class MenuButtonStyle : Style
    {
        public MenuButtonStyle()
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent, Path = new PropertyPath("Background")
            });
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(20, 0, 0, 20));

            borderFactory.AppendChild(contentPresenterFactory);

            Trigger trigger = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            trigger.Setters.Add(new Setter(Button.BackgroundProperty, BasicColors.BackgroundLightBrush));
            trigger.Setters.Add(new Setter(Button.ForegroundProperty, BasicColors.BackgroundDarkBrush));

            Triggers.Add(trigger);
            Setters.Add(new Setter(Button.BackgroundProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(Button.ForegroundProperty, BasicColors.ForegroundWhiteColor));
            Setters.Add(new Setter(Button.FontWeightProperty, FontWeights.Bold));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
