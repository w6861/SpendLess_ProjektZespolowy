using System;
using MediatR;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;
using SpendLess.Infrastructure.Models;

namespace SpendLess.Api.Queries.Expenses
{
    public record UpdateExpenseCommand() : IRequest<bool>
    {
        public UpdateExpense Expense { get; set; }
        public Guid ExpenseId { get; set; }
    }
}

