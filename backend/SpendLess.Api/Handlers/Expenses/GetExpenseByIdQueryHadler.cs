using System;
using MediatR;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Expenses
{
    public record GetExpenseByIdQueryHadler : IRequestHandler<GetExpenseByIdQuery, Expense?>
    {
        private readonly IExpensesRepository _expenseRepository;

        public GetExpenseByIdQueryHadler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<Expense?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetExpense(request.ExpenseId);
        }
    }
}

