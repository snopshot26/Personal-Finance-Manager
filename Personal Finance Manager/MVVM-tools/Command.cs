using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.MVVM_tools
{
    public class Command : BaseCommand
    {
        public Action action;
        public Func<bool> canExecute;

        public Command(Action action, Func<bool> canExecute = null)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            Func<bool> canExecute = this.canExecute;
            return canExecute == null || canExecute();
        }

        public override void Execute(object parameter) => this.action();

    }

    public class Command<T> : BaseCommand
    {
        public Action<T> action;
        public Func<T, bool> canExecute;
        public Command(Action<T> action, Func<T, bool> canExecute = null)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute;
        }
        public override void Execute(object parameter) => this.action((T)parameter);
        public override bool CanExecute(object parameter)
        {
            Func<T, bool> canExecute = this.canExecute;
            return canExecute == null || canExecute((T)parameter);

        }
    }
}
