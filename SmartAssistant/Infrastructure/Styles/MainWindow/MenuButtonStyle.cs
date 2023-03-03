using SmartAssistant.Resources;
using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow
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
            trigger.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush"))); 
            trigger.Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonDarkBrush")));

            Triggers.Add(trigger);
            Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"))); 
            Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush"))); 
            Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
