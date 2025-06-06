using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Manager.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigationService _navService;
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
        public ICommand NavigateBudgetCommand { get; }

        public MainViewModel(INavigationService navService)
        {
            _navService = navService;
            _navService.OnViewModelChanged += vm => CurrentViewModel = vm;

            NavigateLoginCommand = new RelayCommand(async _ => await _navService.NavigateToAsync<LoginViewModel>());
            NavigateRegisterCommand = new RelayCommand(async _ => await _navService.NavigateToAsync<RegistrationViewModel>());
            NavigateBudgetCommand = new RelayCommand(async _ => await _navService.NavigateToAsync<BudgetViewModel>());

            _ = _navService.NavigateToAsync<LoginViewModel>();
        }
    }
}
