using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAssistant.UserControls.Base
{
    public interface INotifyButtonPressed<T>
    {
        public static event Action<T> OnButtonPressed;
    }
}
