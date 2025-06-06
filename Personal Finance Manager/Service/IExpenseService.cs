using Personal_Finance_Manager.Models;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public interface IExpenseService
    {
        Task AddExpenseAsync(decimal amount, string category, string? description = null);

        Task<decimal> GetTotalAmountAsync();
    }
}
