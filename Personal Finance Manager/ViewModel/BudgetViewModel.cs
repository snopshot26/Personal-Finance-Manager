using Personal_Finance_Manager.MVVM_tools;
using Personal_Finance_Manager.Service;
using Personal_Finance_Manager.Strategy;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.ViewModel
{
    public class BudgetViewModel : BaseViewModel, INavigationAware
    {
        private readonly IBudgetStrategy _budgetStrategy;

        private decimal _total;
        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        public BudgetViewModel(IBudgetStrategy budgetStrategy)
        {
            _budgetStrategy = budgetStrategy;
        }

        public async Task OnNavigatedToAsync(object? parameter)
        {
            Total = await _budgetStrategy.GetBudgetAsync();
        }
    }
}
