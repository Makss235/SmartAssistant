using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.AddPEWindow;

namespace SmartAssistant.Infrastructure.Styles.AddPEWindow
{
    public class AddPEMenuButton : Style
    {
        public AddPEMenuButton() 
        {
            CommonButton commonB = new CommonButton();

            FrameworkElementFactory borderF = commonB.borderF;
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));

            MultiTrigger mouseOverBackgroundRedT = new MultiTrigger 
            { 
                Conditions =
                {
                    new Condition{ Property = Button.IsMouseOverProperty, Value = true},
                    new Condition{ Property = Button.BackgroundProperty, Value = ResApp.GetResources<SolidColorBrush>("Red")}
                },
                Setters =
                {
                    new Setter{ Property = Button.ForegroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonLightBrush")},
                    new Setter{ Property = Button.BorderBrushProperty, Value = ResApp.GetResources<SolidColorBrush>("DarkRed")},
                }
            };

            //Trigger tr = new Trigger
            //{
            //    Property = Button.BackgroundProperty,
            //    Value = Application.Current.Resources["Red"]
            //};
            //tr.Setters.Add(new Setter(Button.BorderBrushProperty, Brushes.Yellow));

            commonB.mouseOverT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            commonB.mouseOverT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            commonB.mouseOverT.Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));

            //commonB.pressedT.Setters.Add(new Setter(Button.BorderBrushProperty, Application.Current.Resources["BackgroundDarkBrush"]));

            Triggers.Add(commonB.mouseOverT);
            //Triggers.Add(commonB.pressedT);
            Triggers.Add(mouseOverBackgroundRedT);
            //Triggers.Add(tr);
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderF
            }));
        }
    }
}
