using System;
using MediatR;
using SpendLess.Domain;

namespace SpendLess.Api.Queries.Expenses
{
    public record RemoveExpenseCommand() : IRequest<Unit>
    {
        public Guid ExpenseId { get; set; }
    }
}

