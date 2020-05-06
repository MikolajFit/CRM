using System;
using System.Windows.Input;

namespace CRM.DesktopClient.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public BaseCommand(Action<object> action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }


        public void Execute()
        {
            Execute(null);
        }
    }
}