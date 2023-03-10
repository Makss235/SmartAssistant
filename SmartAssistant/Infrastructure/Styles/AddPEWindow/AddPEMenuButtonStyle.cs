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
    public class AddPEMenuButtonStyle : Style
    {
        public AddPEMenuButtonStyle(double actualHeight, bool isCorrect)
        {
            CommonButton commonB = new CommonButton();

            FrameworkElementFactory borderF = commonB.borderF;
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));

            SolidColorBrush background;

            if (isCorrect)
            {
                background = Brushes.Yellow;
            }
            else
            {
                background = Brushes.Green;
            }

            MultiTrigger mouseOverBDNotRedT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition{ Property = Button.IsMouseOverProperty, Value = true},
                    new Condition{ Property = Button.BorderBrushProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")}
                },
                Setters =
                {
                    new Setter{ Property = Button.BackgroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonLightBrush")},
                    new Setter{ Property = Button.ForegroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")},
                }
            };

            MultiTrigger mouseOverBDRedT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition{ Property = Button.IsMouseOverProperty, Value = true},
                    new Condition{ Property = Button.BorderBrushProperty, Value = ResApp.GetResources<SolidColorBrush>("Red")}
                },
                Setters =
                {
                    new Setter{ Property = Button.BackgroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonLightBrush")},
                    new Setter{ Property = Button.ForegroundProperty, Value = ResApp.GetResources<SolidColorBrush>("Red")},
                }
            };

            MultiTrigger BDNotRedT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition{ Property = Button.IsMouseOverProperty, Value = false},
                    new Condition{ Property = Button.BorderBrushProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")}
                },
                Setters =
                {
                    new Setter{ Property = Button.BackgroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")},
                    new Setter{ Property = Button.ForegroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonLightBrush")},
                    new Setter{ Property = Button.BorderThicknessProperty, Value = new Thickness(0)},
                    new Setter{ Property = Button.HeightProperty, Value = actualHeight + 2},
                }
            };

            MultiTrigger BDRedT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition{ Property = Button.IsMouseOverProperty, Value = false},
                    new Condition{ Property = Button.BorderBrushProperty, Value = ResApp.GetResources<SolidColorBrush>("Red")}
                },
                Setters =
                {
                    new Setter{ Property = Button.BackgroundProperty, Value = ResApp.GetResources<SolidColorBrush>("Red")},
                    new Setter{ Property = Button.ForegroundProperty, Value = ResApp.GetResources<SolidColorBrush>("CommonLightBrush")},
                    new Setter{ Property = Button.BorderThicknessProperty, Value = new Thickness(0)},
                    new Setter{ Property = Button.HeightProperty, Value = actualHeight + 2},
                }
            };

            //Triggers.Add(mouseOverBDNotRedT);
            //Triggers.Add(mouseOverBDRedT);
            //Triggers.Add(BDNotRedT);
            //Triggers.Add(BDRedT);
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Button.BackgroundProperty, background/*ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")*/));
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
