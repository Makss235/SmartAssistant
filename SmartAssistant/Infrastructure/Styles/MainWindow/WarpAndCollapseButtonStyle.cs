using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow
{
    public class WarpAndCollapseProgramButtonStyle : Style
    {
        // TODO: Veser нормальный конструктор
        public WarpAndCollapseProgramButtonStyle(CornerRadius cornerRadius, SolidColorBrush TriggerBackGroundColor)
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.CornerRadiusProperty, cornerRadius);
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
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            MouseOverTrigger.Setters.Add(new Setter(Control.BackgroundProperty, TriggerBackGroundColor));

            Triggers.Add(MouseOverTrigger);
            Setters.Add(new Setter(Control.BackgroundProperty, Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush));
            Setters.Add(new Setter(FrameworkElement.WidthProperty, (double)40));
            Setters.Add(new Setter(FrameworkElement.HeightProperty, (double)36));
            Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top));
            Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right));
            Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
