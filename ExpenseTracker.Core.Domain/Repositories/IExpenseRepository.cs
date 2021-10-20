using ExpenseTracker.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();

        Task<IEnumerable<Expense>> GetExpensesByCategory(ExpenseCategory category);

        Task AddExpenseAsync(Expense expense);

        Task DeleteExpenseAsync(Guid id);

        Task UpdateExpenseAsync(Expense expense);
    }
}
