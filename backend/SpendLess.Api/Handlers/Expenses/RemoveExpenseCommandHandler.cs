using System;
using MediatR;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Expenses
{
    public record RemoveExpenseCommandHandler : IRequestHandler<RemoveExpenseCommand, Unit>
    {
        private readonly IExpensesRepository _expenseRepository;

        public RemoveExpenseCommandHandler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<Unit> Handle(RemoveExpenseCommand request, CancellationToken cancellationToken)
        {
            await _expenseRepository.RemoveExpense(request.ExpenseId);
            return Unit.Value;
        }
    }
}

