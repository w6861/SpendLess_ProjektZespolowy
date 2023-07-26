using MediatR;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Expences
{
    public record AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, Guid>
    {
        private readonly IExpensesRepository _expenseRepository;

        public AddExpenseCommandHandler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<Guid> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.AddExpense(request.Expense);
        }
    }
}

