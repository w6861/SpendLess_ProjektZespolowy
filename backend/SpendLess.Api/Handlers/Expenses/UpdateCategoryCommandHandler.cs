using System;
using MediatR;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Expenses
{
    public record UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, bool>
    {
        private readonly IExpensesRepository _expenseRepository;

        public UpdateExpenseCommandHandler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }


        public async Task<bool> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.UpdateExpense(request.ExpenseId, request.Expense);
        }
    }
}

