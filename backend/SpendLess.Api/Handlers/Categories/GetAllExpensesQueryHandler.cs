using System;
using MediatR;
using SpendLess.Api.Queries;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Categories
{
    public record GetAllExpensesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IList<Category>>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public GetAllExpensesQueryHandler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IList<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllCategories();
        }
    }
}

