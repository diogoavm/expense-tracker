using ExpenseTracker.Core.Domain.Models;
using ExpenseTracker.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly IExpenseRepository _repoWrapper;

        public ExpensesController(IExpenseRepository repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Expense> expenses = await _repoWrapper.GetAllAsync();

            float totalExpense = 0;

            foreach (var item in expenses)
            {
                totalExpense += item.Value;
            }

            return Ok(new { expenses, totalExpense });
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(Expense expense)
        {
            expense.Id = Guid.NewGuid();

            await _repoWrapper.AddExpenseAsync(expense);

            return Ok(expense);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesByCategory(ExpenseCategory category)
        {
            IEnumerable<Expense> expenses = await _repoWrapper.GetExpensesByCategory(category);

            float totalExpense = 0;

            foreach (var item in expenses)
            {
                totalExpense += item.Value;
            }

            return Ok(new { expenses, totalExpense });
        }
    }
}
