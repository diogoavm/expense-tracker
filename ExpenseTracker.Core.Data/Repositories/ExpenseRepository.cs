using ExpenseTracker.Core.Domain.Models;
using ExpenseTracker.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly RepositoryContext _context;

        public ExpenseRepository(RepositoryContext context) 
        {
            _context = context;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(Guid id)
        {
            _context.Entry(expense).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategory(ExpenseCategory category)
        {
            return await _context.Expenses.Where(c => c.Category == category).ToListAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;

            await(_context.SaveChangesAsync());
        }
    }
}
