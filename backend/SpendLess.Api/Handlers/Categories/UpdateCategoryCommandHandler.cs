using System;
using MediatR;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Categories
{
    public record UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.UpdateCategory(request.CategoryId, request.Category);
        }
    }
}

