using ExpenseTracker.Core.Domain.Models;
using ExpenseTracker.Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            (IEnumerable<Expense> expenses, float totalExpense) = await _expenseService.GetAllAsync();

            return Ok(new { expenses, totalExpense });
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(Expense expense)
        {
            await _expenseService.CreateExpense(expense);

            return Ok(expense);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesByCategory(ExpenseCategory category)
        {
            (IEnumerable<Expense> expenses, float totalExpense) = await _expenseService.GetExpensesByCategory(category);

            return Ok(new { expenses, totalExpense });
        }
    }
}
