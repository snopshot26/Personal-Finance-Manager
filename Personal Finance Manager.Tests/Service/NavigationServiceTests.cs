using Microsoft.Extensions.DependencyInjection;
using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using System.Threading.Tasks;
using Xunit;

namespace Personal_Finance_Manager.Tests.Service
{
    public class NavigationServiceTests
    {
        private class DummyViewModel : BaseViewModel { }

        [Fact]
        public async Task NavigateToAsync_RaisesEvent()
        {
            var services = new ServiceCollection();
            services.AddSingleton<DummyViewModel>();
            var provider = services.BuildServiceProvider();
            var service = new AppNavigationService(provider);
            BaseViewModel? changed = null;
            service.OnViewModelChanged += vm => changed = vm;

            await service.NavigateToAsync<DummyViewModel>();

            Assert.IsType<DummyViewModel>(changed);
        }
    }
}
