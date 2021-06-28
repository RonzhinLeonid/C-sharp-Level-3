using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CommandExample
{
    class DelegateCommand : ICommand
    {
        private Func<object, bool> canExecute;
        private Action<object> execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)

        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
