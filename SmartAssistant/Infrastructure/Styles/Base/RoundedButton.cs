using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class RoundedButton : Style
    {
        /// <summary>
        /// Базовый шаблон для кнопки с закругленными углами
        /// </summary>
        /// <param name="cornerRadius">Угловой радиус кнопки</param>
        /// <param name="borderThickness">Ширина границы</param>
        /// <param name="backgroundBrush">Цвет фона</param>
        /// <param name="foregroundBrush">Цвет шрифта</param>
        /// <param name="borderBrush">Цвет границы</param>
        /// <param name="mouseOverBackgroundBrush">Цвет фона при наведении мыши</param>
        /// <param name="mouseOverForegroundBrush">Цвет шрифта при наведении мыши</param>
        /// <param name="mouseOverBorderBrush">Цвет границы при наведении мыши</param>
        public RoundedButton(
            CornerRadius cornerRadius,
            Thickness borderThickness,
            SolidColorBrush backgroundBrush,
            SolidColorBrush foregroundBrush,
            SolidColorBrush borderBrush,
            SolidColorBrush mouseOverBackgroundBrush,
            SolidColorBrush mouseOverForegroundBrush,
            SolidColorBrush mouseOverBorderBrush
            )

        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetBinding(FrameworkElement.MarginProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

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
            borderFactory.SetBinding(Border.BorderThicknessProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderThickness")
            });
            borderFactory.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderFactory.SetValue(Border.BorderThicknessProperty, borderThickness);

            borderFactory.AppendChild(contentPresenterFactory);

            Trigger mouseOverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverTrigger.Setters.Add(new Setter(Control.BackgroundProperty, mouseOverBackgroundBrush));
            mouseOverTrigger.Setters.Add(new Setter(Control.ForegroundProperty, mouseOverForegroundBrush));
            mouseOverTrigger.Setters.Add(new Setter(Control.BorderBrushProperty, mouseOverBorderBrush));
            mouseOverTrigger.Setters.Add(new Setter(Control.BorderThicknessProperty, borderThickness));

            Triggers.Add(mouseOverTrigger);
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(Control.BackgroundProperty, backgroundBrush));
            Setters.Add(new Setter(Control.ForegroundProperty, foregroundBrush));
            Setters.Add(new Setter(Control.BorderBrushProperty, borderBrush));
            Setters.Add(new Setter(Control.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
