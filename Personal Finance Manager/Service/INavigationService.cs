using Personal_Finance_Manager.MVVM_tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel;
        event Action<BaseViewModel> OnViewModelChanged;
    }

}
