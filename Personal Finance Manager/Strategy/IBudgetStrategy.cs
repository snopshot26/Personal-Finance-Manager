using System.Threading.Tasks;

namespace Personal_Finance_Manager.Strategy
{
    public interface IBudgetStrategy
    {
        Task<decimal> GetBudgetAsync();
    }
}
