using ExpenseTracker.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();

        Task<IEnumerable<Domain.Models.Expense>> GetExpensesByCategory(ExpenseCategory category);

        Task AddExpenseAsync(Expense expense);

        Task<int> DeleteExpenseAsync(Guid id);

        Task<int> UpdateExpenseAsync(Expense expense);
    }
}
