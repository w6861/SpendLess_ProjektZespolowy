using System;
using MediatR;
using SpendLess.Api.Queries;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Categories
{
    public record GetCategoryByIdQueryHadler : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public GetCategoryByIdQueryHadler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategory(request.CategoryId);
        }
    }
}

