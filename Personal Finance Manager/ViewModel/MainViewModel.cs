using Personal_Finance_Manager.Message;
using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel? _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => ChangeProperty(out _currentViewModel, value);
        }

        public MainViewModel(IMessanger messanger)
        {
            messanger.Subscribe<NavigationMessage>(item =>
            {
                var message = item as NavigationMessage;
                var type = message?.ViewModelType;
                if (type == typeof(LoginViewModel))
                {
                    this.CurrentViewModel = App.LoginViewModel;
                }
                if (type == typeof(RegistrationViewModel))
                {
                    this.CurrentViewModel = App.RegistrationViewModel;
                }
            });
        }
    }
}
