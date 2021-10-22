using ExpenseTracker.Core.Domain.Models;
using ExpenseTracker.Core.Domain.Repositories;
using ExpenseTracker.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Data
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<bool> CreateExpense(Expense expense)
        {
            bool isCreated = false;

            try
            {
                await _expenseRepository.AddExpenseAsync(expense);
                isCreated = true;
            }
            catch(Exception ex)
            {
                isCreated = false;
            }

            return isCreated;
        }

        public async Task<bool> DeleteExpense(Guid id)
        {
            bool isDeleted=false;

            int changes = await _expenseRepository.DeleteExpenseAsync(id);

            if (changes > 0)
                isDeleted = true;

            return isDeleted;
        }

        public async Task<(IEnumerable<Expense>, float)> GetAllAsync()
        {
            IEnumerable<Expense> expenses = await _expenseRepository.GetAllAsync();

            int totalExpense = 0;

            foreach (var item in expenses)
            {
                totalExpense += item.Value;
            }

            return (expenses, totalExpense);
        }

        public async Task<(IEnumerable<Expense>, float)> GetExpensesByCategory(ExpenseCategory category)
        {
            IEnumerable<Expense> expenses = await _expenseRepository.GetExpensesByCategory(category);

            int totalExpense = 0;

            foreach (var item in expenses)
            {
                totalExpense += item.Value;
            }

            return (expenses, totalExpense);
        }
    }
}
