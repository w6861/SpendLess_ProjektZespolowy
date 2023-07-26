using System;
using MediatR;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain;
using SpendLess.Domain.Interfaces;

namespace SpendLess.Api.Handlers.Categories
{
    public record RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public RemoveCategoryCommandHandler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.RemoveCategory(request.CategoryId);
            return Unit.Value;
        }
    }
}

