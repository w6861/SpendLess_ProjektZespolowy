using System;
using MediatR;
using SpendLess.Api.Queries;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Expences
{
    public record GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, IList<Expense>>
    {
        private readonly IExpensesRepository _expenseRepository;

        public GetAllExpensesQueryHandler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IList<Expense>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetAllExpenses();
        }
    }
}