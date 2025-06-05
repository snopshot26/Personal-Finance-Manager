using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal_Finance_Manager.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navService;

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public RegistrationViewModel(IUserService userService, INavigationService navService)
        {
            _userService = userService;
            _navService = navService;
            RegisterCommand = new RelayCommand(async p => await RegisterAsync(p as string));
            NavigateLoginCommand = new RelayCommand(async _ => await _navService.NavigateToAsync<LoginViewModel>());
        }

        private async Task RegisterAsync(string? password)
        {
            await _userService.RegisterAsync(Username, password ?? string.Empty);
            MessageBox.Show("Registration successful");
        }
    }
}
