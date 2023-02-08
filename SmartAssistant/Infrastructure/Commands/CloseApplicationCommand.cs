using SmartAssistant.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartAssistant.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public static event Action CloseApplicationEvent;

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            bool parseResult = bool.TryParse(parameter.ToString(), out var canClose);
            if (parseResult)
            {
                if (canClose)
                {
                    CloseApplicationEvent?.Invoke();
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
