using ExpenseTracker.Core.Data.Models;
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

        public async Task AddExpenseAsync(Domain.Models.Expense expense)
        {
            await _context.Expenses.AddAsync(expense.ToPersistenceModel());

            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExpenseAsync(Guid id)
        {
            Domain.Models.Expense expense = await _context.Expenses.Select(x => x.ToDomainModel()).FirstOrDefaultAsync();

            if(expense!=null)
                _context.Expenses.Remove(expense.ToPersistenceModel());

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Models.Expense>> GetAllAsync()
        { 
            return await _context.Expenses.Select(x => x.ToDomainModel()).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Expense>> GetExpensesByCategory(ExpenseCategory category)
        {
            return await _context.Expenses.Where(c => c.Category == category).Select(x => x.ToDomainModel()).ToListAsync();
        }

        public async Task<int> UpdateExpenseAsync(Domain.Models.Expense expense)
        {
            _context.Expenses.Update(expense.ToPersistenceModel());

            return await _context.SaveChangesAsync();
        }
    }
}
