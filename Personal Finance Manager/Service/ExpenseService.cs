using Personal_Finance_Manager.Models;
using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly FinanceContext _context;

        public ExpenseService(FinanceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task AddExpenseAsync(decimal amount, string category, string? description = null)
        {
            var expense = new Expense
            {
                Amount = amount,
                Category = category,
                Date = System.DateTime.Now,
                Description = description
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }
    }
}
