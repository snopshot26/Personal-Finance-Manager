using Personal_Finance_Manager.Service;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Strategy
{
    public class TotalExpenseBudgetStrategy : IBudgetStrategy
    {
        private readonly IExpenseService _expenseService;

        public TotalExpenseBudgetStrategy(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<decimal> GetBudgetAsync()
        {
            return await _expenseService.GetTotalAmountAsync();
        }
    }
}
