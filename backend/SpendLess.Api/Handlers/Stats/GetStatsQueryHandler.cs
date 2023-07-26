using MediatR;
using SpendLess.Api.Queries.Raports;
using SpendLess.Api.Queries.Stats;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;
using SpendLess.Infrastructure.Repositories;

namespace SpendLess.Api.Handlers.Stats
{
    public class GetStatsQueryHandler : IRequestHandler<GetStatsQuery, Statistics>
    {
        private readonly IRaportsRepository _raportsRepository;

        public GetStatsQueryHandler(IRaportsRepository raportsRepository)
        {
            _raportsRepository = raportsRepository;
        }

        public async Task<Statistics> Handle(GetStatsQuery request, CancellationToken cancellationToken)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var allTimeRaport = await _raportsRepository.GetRaport(new GetRaport { To = new DateTime(currentYear, currentMonth, 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59) });   //get raport to last month
            var thisMonthRaport = await _raportsRepository.GetRaport(new GetRaport
            {
                From = new DateTimeOffset(new DateTime(currentYear, currentMonth, 1)), //first day of current month
                To = DateTimeOffset.Now
            });   //get raport from beginning of this month to now

            var warnings = new List<string>();
            foreach (var category in thisMonthRaport.MostExpensiveCategories)
            {
                var currentMonthCategorySpent = category?.ExpensesSum;
                if (currentMonthCategorySpent > 0)
                {
                    var allTimeAvgCategorySpent = allTimeRaport.MostExpensiveCategories?.FirstOrDefault(c => c.CategoryName == category?.CategoryName)?.ExpensesSum;
                    if (category?.ExpensesSum > allTimeAvgCategorySpent)
                    {
                        warnings.Add($"Przekroczyłeś/aś w tym miesiącu średnie wydatki dla kategorii {category.CategoryName} o {category.ExpensesSum - allTimeAvgCategorySpent} zł!");
                    }
                }
            }
            return new Statistics { Warnings = warnings };
        }
    }
}

