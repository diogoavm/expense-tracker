using ExpenseTracker.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Domain.Services
{
    public interface IExpenseService
    {
        Task<(IEnumerable<Expense>, float)> GetAllAsync();

        Task<bool> CreateExpense(Expense expense);

        Task<bool> DeleteExpense(Guid id);

        Task<(IEnumerable<Expense>, float)> GetExpensesByCategory(ExpenseCategory category);
    }
}
