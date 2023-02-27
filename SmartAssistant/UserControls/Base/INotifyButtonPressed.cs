using System;

namespace SmartAssistant.UserControls.Base
{
    public interface INotifyButtonPressed<T>
    {
        public static event Action<T> ButtonPressed;
    }
}
