using ExpenseTracker.Core.Domain.Models;
using ExpenseTracker.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Data.Repositories
{
    class ExpenseRepository : Expense, IExpense
    {
        Task IExpense.DeleteExpenseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Expense> IExpense.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Expense> IExpense.GetExpenseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Expense> IExpense.UpdateExpenseAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
