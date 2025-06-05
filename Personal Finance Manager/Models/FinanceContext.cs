using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Personal_Finance_Manager.Models
{
    public class FinanceContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public string DbPath { get; }

        public FinanceContext() { }

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        {
            var folder = Directory.GetCurrentDirectory();
            DbPath = Path.Join(folder, "finance.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"Data Source={DbPath}");
            }
        }
    }
}
