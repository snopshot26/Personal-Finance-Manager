using Personal_Finance_Manager.Service;
using Personal_Finance_Manager.View;
using Personal_Finance_Manager.ViewModel;
using System.Configuration;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;

namespace Personal_Finance_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MainViewModel _mainViewModel;
        private static LoginViewModel _loginViewModel;
        private static RegistrationViewModel _registrationViewModel;

        public static MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set => _mainViewModel = value;
        }

        public static LoginViewModel LoginViewModel
        {
            get => _loginViewModel;
            set => _loginViewModel = value;
        }

        public static RegistrationViewModel RegistrationViewModel
        {
            get => _registrationViewModel;
            set => _registrationViewModel = value;
        }

        private static IMessanger _messenger;
        public static IMessanger Messenger
        {
            get => _messenger;
            set => _messenger = value;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Messenger = new Messanger();

            // ViewModels initialization can be done here
            MainViewModel = new MainViewModel(Messenger);
            LoginViewModel = new LoginViewModel(Messenger);
            RegistrationViewModel = new RegistrationViewModel(Messenger);

            MainView mainView = new()
            {
                DataContext = MainViewModel
            };
            MainViewModel.CurrentViewModel = LoginViewModel;

            mainView.ShowDialog();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Clean up resources or save settings before exiting
            base.OnExit(e);
        }
    }

}
