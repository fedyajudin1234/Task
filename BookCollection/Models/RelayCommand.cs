using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookCollection.Models
{
    public class RelayCommand: ICommand
    {
        private Action<object> action;
        private Func<object, bool> func;

        public event EventHandler? CanExecuteChanged;

        public event EventHandler CanExecute
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove 
            {
                CommandManager.RequerySuggested -= value; 
            }
        }

        public RelayCommand(Action<object> action, Func<object, bool> func = null)
        {
            this.action = action;
            this.func = func;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return func == null || func(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
