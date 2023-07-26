using Microsoft.EntityFrameworkCore;
using SpendLess.Api;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Infrastructure.Repositories
{
    public class RaportsRepository : IRaportsRepository
    {
        private readonly SpendLessContext _context;

        public RaportsRepository(SpendLessContext context)
        {
            _context = context;
        }

        public async Task<Raport> GetRaport(GetRaport query)
        {
            var categoryExpenses = await (from category in _context.Categories
                                          join e in _context.Expenses on category equals e.Category into leftJoin
                                          from expense in leftJoin.DefaultIfEmpty()
                                          group expense by category into categoriesGrouped
                                          orderby categoriesGrouped.Sum(x => x.Amount) descending
                                          select new CategoryExpense
                                          {
                                              CategoryName = categoriesGrouped.Key.Name,
                                              ExpensesSum = categoriesGrouped.Where(x => query.To.HasValue ? x.ExpenseDate <= query.To : true)
                                                                             .Where(x => query.From.HasValue ? x.ExpenseDate >= query.From : true)
                                                                             .Sum(x => x.Amount)
                                          }).AsNoTracking()
                                            .ToListAsync();

            return new Raport { MostExpensiveCategories = categoryExpenses };
        }
    }
}

