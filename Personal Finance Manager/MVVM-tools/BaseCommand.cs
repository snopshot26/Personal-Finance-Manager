using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.MVVM_tools
{
    public abstract class BaseCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void NotifyCanExecuteChanged()
        {
            EventHandler CanExecuteChanged = this.CanExecuteChanged;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
