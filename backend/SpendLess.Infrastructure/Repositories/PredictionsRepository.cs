using Microsoft.EntityFrameworkCore;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Infrastructure.Repositories
{
    public class PredictionsRepository : IPredictionsRepository
    {
        private readonly SpendLessContext _context;

        public PredictionsRepository(SpendLessContext context)
        {
            _context = context;
        }

        public async Task<Prediction> GetPrediction()
        {
            var expensesForCategoryGroupedByMonth = await _context.Expenses.Include(e => e.Category)
                                                                           .GroupBy(e => new { e.Category.Name, e.ExpenseDate.Month })
                                                                           .Select(e => new { e.Key.Name, e.Key.Month, Avg = e.Average(e => e.Amount) })
                                                                           .GroupBy(x => x.Name)
                                                                           .Select(x => new CategoryAverageExpense
                                                                           {
                                                                               CategoryName = x.Key ?? "Brak kategorii",
                                                                               ExpensesAvg = x.Average(x => x.Avg)
                                                                           })
                                                                           .AsNoTracking()
                                                                           .ToListAsync();

            expensesForCategoryGroupedByMonth.ForEach(e => e.ExpensesAvg = Math.Round(e.ExpensesAvg ?? 0, 2));
            return new Prediction { CategoryPredictions = expensesForCategoryGroupedByMonth };
        }
    }
}

