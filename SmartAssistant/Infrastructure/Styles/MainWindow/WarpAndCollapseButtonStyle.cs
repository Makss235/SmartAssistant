using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow
{
    public class WarpAndCollapseProgramButtonStyle : Style
    {
        // TODO: Veser нормальный конструктор
        public WarpAndCollapseProgramButtonStyle(CornerRadius cornerRadius ,double textWidth, double textHeight, SolidColorBrush TriggerBackGroundColor)
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.WidthProperty, textWidth);
            contentPresenterFactory.SetValue(ContentPresenter.HeightProperty, textHeight);
            contentPresenterFactory.SetBinding(ContentPresenter.MarginProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

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
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            MouseOverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, TriggerBackGroundColor));

            Triggers.Add(MouseOverTrigger);
            Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.WidthProperty, (double)40));
            Setters.Add(new Setter(Button.HeightProperty, (double)36));
            Setters.Add(new Setter(Button.VerticalAlignmentProperty, VerticalAlignment.Top));
            Setters.Add(new Setter(Button.HorizontalAlignmentProperty, HorizontalAlignment.Right));
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
