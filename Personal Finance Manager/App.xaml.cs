using Personal_Finance_Manager.Service;
using Personal_Finance_Manager.Models;
using Personal_Finance_Manager.View;
using Personal_Finance_Manager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Navigation;

namespace Personal_Finance_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            Services = services.BuildServiceProvider();

            var mainWindow = Services.GetRequiredService<MainView>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistrationViewModel>();

            // Views
            services.AddSingleton<MainView>();

            // Services
            services.AddSingleton<INavigationService, AppNavigationService>();
            services.AddDbContext<FinanceContext>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IExpenseService, ExpenseService>();
        }
    }

}
