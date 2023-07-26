using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            return Ok(await _mediator.Send(new GetAllExpensesQuery()));
        }

        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpenseById(Guid expenseId)
        {
            return Ok(await _mediator.Send(new GetExpenseByIdQuery { ExpenseId = expenseId }));
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] AddExpense expense)
        {
            return Ok(await _mediator.Send(new AddExpenseCommand { Expense = expense }));
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> UpdateExpense(Guid expenseId, [FromBody] UpdateExpense expense)
        {
            return Ok(await _mediator.Send(new UpdateExpenseCommand { ExpenseId = expenseId, Expense = expense }));
        }

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> RemoveExpense(Guid expenseId)
        {
            return Ok(await _mediator.Send(new RemoveExpenseCommand { ExpenseId = expenseId }));
        }
    }
}

