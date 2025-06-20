﻿using Microsoft.Extensions.DependencyInjection;
using Personal_Finance_Manager.MVVM_tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public class AppNavigationService : INavigationService
    {
        private readonly IServiceProvider _provider;
        public event Action<BaseViewModel> OnViewModelChanged;

        public AppNavigationService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel
        {
            var viewModel = _provider.GetRequiredService<TViewModel>();
            if (viewModel is INavigationAware aware)
            {
                await aware.OnNavigatedToAsync(parameter);
            }
            OnViewModelChanged?.Invoke(viewModel);
        }
    }

}
