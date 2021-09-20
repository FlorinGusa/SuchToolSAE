using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GoSearchSAE
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> ExecuteAction;
        Predicate<object> CanExecutePredicate;

        public Command(Action<object> executeAction, Predicate<object> predicateAction = null)
        {
            ExecuteAction = executeAction;
            CanExecutePredicate = predicateAction;
        }


        public bool CanExecute(object parameter) => CanExecutePredicate == null || CanExecutePredicate(parameter);
        
        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }

        public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
