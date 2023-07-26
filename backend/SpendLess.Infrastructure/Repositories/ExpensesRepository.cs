using Microsoft.EntityFrameworkCore;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;
using SpendLess.Infrastructure.Models;

namespace SpendLess.Infrastructure.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly SpendLessContext _context;

        public ExpensesRepository(SpendLessContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddExpense(AddExpense expense)
        {
            if (expense.CategoryId.HasValue && !await _context.Categories.AsNoTracking().AnyAsync(c => c.CategoryId == expense.CategoryId))
            {
                throw new Exception($"Category {expense.CategoryId} not found");
            }

            var newExpense = new DbExpense
            {
                ExpenseId = Guid.NewGuid(),
                Name = expense.Name,
                Description = expense.Description,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                CreationDate = DateTimeOffset.Now,
                CategoryId = expense.CategoryId,
            };

            await _context.Expenses.AddAsync(newExpense);
            await _context.SaveChangesAsync();
            return newExpense.ExpenseId;
        }

        public async Task<IList<Expense>> GetAllExpenses()
        {
            return await _context.Expenses.Include(e => e.Category).Select(e => new Expense
            {
                ExpenseId = e.ExpenseId,
                Name = e.Name,
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                CreationDate = e.CreationDate,
                Category = e.CategoryId.HasValue ? new Category { CategoryId = e.Category.CategoryId, Name = e.Category.Name } : null
            }).AsNoTracking()
              .OrderByDescending(e => e.ExpenseDate)
              .ToListAsync();
        }

        public async Task<Expense?> GetExpense(Guid expenseId)
        {
            return await _context.Expenses.Select(e => new Expense
            {
                ExpenseId = e.ExpenseId,
                Name = e.Name,
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                CreationDate = e.CreationDate,
                Category = e.CategoryId.HasValue ? new Category { CategoryId = e.Category.CategoryId, Name = e.Category.Name } : null
            }).AsNoTracking()
              .FirstOrDefaultAsync(c => c.ExpenseId == expenseId);
        }

        public async Task RemoveExpense(Guid expenseId)
        {
            var expenseToRemove = await _context.Expenses.FindAsync(expenseId);
            if (expenseToRemove is null)
            {
                throw new Exception($"Expense {expenseId} not found");
            }

            var removeContext = _context.Remove(expenseToRemove);
            await removeContext.Context.SaveChangesAsync();
            return;
        }

        public async Task<bool> UpdateExpense(Guid expenseId, UpdateExpense updateExpense)
        {
            if (updateExpense.CategoryId.HasValue && !await _context.Categories.AsNoTracking().AnyAsync(c => c.CategoryId == updateExpense.CategoryId))
            {
                throw new Exception($"Category {updateExpense.CategoryId} not found");
            }

            var expenseToUpdate = await _context.Expenses.FindAsync(expenseId);
            if (expenseToUpdate is null)
            {
                throw new Exception($"Expense {expenseId} not found");
            }

            expenseToUpdate.Name = updateExpense.Name;
            expenseToUpdate.Description = updateExpense.Description;
            expenseToUpdate.Amount = updateExpense.Amount;
            expenseToUpdate.ExpenseDate = updateExpense.ExpenseDate;
            if (updateExpense.CategoryId != null)
                expenseToUpdate.CategoryId = updateExpense.CategoryId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

