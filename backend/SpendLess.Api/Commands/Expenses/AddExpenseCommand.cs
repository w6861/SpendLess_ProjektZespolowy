using MediatR;
using SpendLess.Domain.ApiModels;

namespace SpendLess.Api.Queries.Expenses
{
    public record AddExpenseCommand() : IRequest<Guid>
    {
        public AddExpense Expense { get; set; }
    }
}

