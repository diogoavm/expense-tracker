using ExpenseTracker.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Domain.Repositories
{
    public interface IExpense
    {
        public Task<Expense> GetAllAsync();

        public Task<Expense> GetExpenseByIdAsync(Guid id);

        public Task DeleteExpenseAsync(Guid id);

        public Task<Expense> UpdateExpenseAsync(Guid id);
    }
}
