using Personal_Finance_Manager.Models;
using Personal_Finance_Manager.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            if (amount <= 0)
            {
                throw new InvalidExpenseException("Amount must be greater than zero");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new InvalidExpenseException("Category is required");
            }

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

        public async Task<decimal> GetTotalAmountAsync()
        {
            return await _context.Expenses.SumAsync(e => e.Amount);
        }
    }
}
