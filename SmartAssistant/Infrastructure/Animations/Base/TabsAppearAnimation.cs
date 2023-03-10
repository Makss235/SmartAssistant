using SmartAssistant.UserControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace SmartAssistant.Infrastructure.Animations.Base
{
    public class TabsAppearAnimation : Storyboard
    {
        public Storyboard tabsAppearAnimSB;

        public TabsAppearAnimation(Tab animatedTab)
        {
            DoubleAnimation tabsAppearAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(200),
            };

            tabsAppearAnimSB = new Storyboard();
            tabsAppearAnimSB.Children.Add(tabsAppearAnim);

            Storyboard.SetTargetProperty(tabsAppearAnim, new PropertyPath(Tab.OpacityProperty));
            Storyboard.SetTarget(tabsAppearAnim, animatedTab);
        }

        public void AnimationStart(Object sender, RoutedEventArgs e)
        {
            tabsAppearAnimSB.Begin();
        }
    }
}
