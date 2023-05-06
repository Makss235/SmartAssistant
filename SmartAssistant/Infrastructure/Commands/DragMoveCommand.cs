using SmartAssistant.Infrastructure.Commands.Base;
using System.Windows;

namespace SmartAssistant.Infrastructure.Commands
{
    internal class DragMoveCommand : Command
    {
        Window Window { get; set; }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Window.DragMove(); //228 CCRF
        }

        internal DragMoveCommand(Window window)
        {
            Window = window;
        }
    }
}
