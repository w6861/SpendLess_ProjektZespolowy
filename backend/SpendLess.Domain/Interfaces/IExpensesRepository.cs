using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Domain.Interfaces
{
    public interface IExpensesRepository
    {
        Task<Expense?> GetExpense(Guid expenseId);
        Task<Guid> AddExpense(AddExpense expense);
        Task RemoveExpense(Guid expenseId);
        Task<bool> UpdateExpense(Guid expenseId, UpdateExpense updateExpense);
        Task<IList<Expense>> GetAllExpenses();
    }
}

