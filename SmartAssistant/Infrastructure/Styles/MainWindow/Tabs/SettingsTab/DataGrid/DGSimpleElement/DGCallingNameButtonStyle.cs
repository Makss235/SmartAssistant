using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement
{
    public class DGCallingNameButtonStyle : Style
    {
        public DGCallingNameButtonStyle(CornerRadius cornerRadius, double fontSize, Thickness contentPresenterMargin)
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.MarginProperty, contentPresenterMargin);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderFactory.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderFactory.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1));

            borderFactory.AppendChild(contentPresenterFactory);

            Trigger mouseOverTrigger = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true,
            };
            mouseOverTrigger.Setters.Add(new Setter(Button.BackgroundProperty, Application.Current.Resources["BackgroundLightBrush"]));
            mouseOverTrigger.Setters.Add(new Setter(Button.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"]));
            mouseOverTrigger.Setters.Add(new Setter(Button.ForegroundProperty, Application.Current.Resources["BackgroundDarkBrush"]));

            Trigger pressedTrigger = new Trigger
            {
                Property = Button.IsPressedProperty,
                Value = true,
            };
            pressedTrigger.Setters.Add(new Setter(Button.BorderBrushProperty, Application.Current.Resources["ButtonPressedBrush"]));

            Triggers.Add(pressedTrigger);
            Triggers.Add(mouseOverTrigger);
            Setters.Add(new Setter(Button.BackgroundProperty, Application.Current.Resources["BackgroundMediumBrush"]));
            Setters.Add(new Setter(Button.BorderBrushProperty, Application.Current.Resources["BackgroundDarkBrush"]));
            Setters.Add(new Setter(Button.ForegroundProperty, Application.Current.Resources["BackgroundLightBrush"]));
            Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Button.FontSizeProperty, fontSize));
            Setters.Add(new Setter(Button.HeightProperty, (double)40));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
