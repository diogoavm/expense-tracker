using ExpenseTracker.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Core.Data.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
