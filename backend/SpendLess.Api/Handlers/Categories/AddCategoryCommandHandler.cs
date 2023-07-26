using System;
using MediatR;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Categories
{
    public record AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.AddCategory(request.Category);
        }
    }
}

