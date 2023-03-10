using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SmartAssistant.Infrastructure.Animations.MainWindow.Tabs.VAChatTab
{
    public class GrowMessageAnimation : Storyboard
    {
        private Storyboard growAnimationSB;
        public GrowMessageAnimation(TextBox animatedTB) 
        {
            animatedTB.RenderTransformOrigin = new Point(1.0, 1.0);
            animatedTB.RenderTransform = new ScaleTransform(1.0, 1.0);

            DoubleAnimation growAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(100),
            };

            growAnimationSB = new Storyboard();
            growAnimationSB.Children.Add(growAnimation);

            Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(growAnimation, animatedTB);
        }

        public void growAnimationStart(Object sender, RoutedEventArgs e)
        {
            growAnimationSB.Begin();
        }
    }
}
