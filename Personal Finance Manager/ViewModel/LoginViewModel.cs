using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal_Finance_Manager.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navService;

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }

        public LoginViewModel(IUserService userService, INavigationService navService)
        {
            _userService = userService;
            _navService = navService;
            LoginCommand = new RelayCommand(async p => await LoginAsync(p as string));
            NavigateRegisterCommand = new RelayCommand(async _ => await _navService.NavigateToAsync<RegistrationViewModel>());
        }

        private async Task LoginAsync(string? password)
        {
            try
            {
                await _userService.AuthenticateAsync(Username, password ?? string.Empty);
                MessageBox.Show("Login successful");
                await _navService.NavigateToAsync<BudgetViewModel>();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
