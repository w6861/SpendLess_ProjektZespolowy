using System;
using MediatR;
using SpendLess.Domain.Models;
using SpendLess.Infrastructure.Models;

namespace SpendLess.Api.Queries.Expenses
{
    public record GetExpenseByIdQuery : IRequest<Expense?>
    {
        public Guid ExpenseId { get; set; }
    }
}

