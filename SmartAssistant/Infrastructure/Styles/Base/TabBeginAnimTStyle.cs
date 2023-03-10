using SmartAssistant.Infrastructure.Animations.Base;
using SmartAssistant.UserControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class TabBeginAnimTStyle : Style
    {
        public TabBeginAnimTStyle(Tab animatedTab) 
        {
            Trigger beginAnimT = new Trigger
            {
                Property = Tab.VisibilityProperty,
                Value = Visibility.Visible,
            };
            //TabsAppearAnimation g = new TabsAppearAnimation(animatedTab);
            //beginAnimT.EnterActions.Add()

            DoubleAnimation a = new DoubleAnimation();
            DoubleAnimation g = new DoubleAnimation();
            //beginAnimT.EnterActions.Add();
        }
    }
}
