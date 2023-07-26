using System;
using MediatR;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Categories
{
    public record GetCategoryByIdQuery : IRequest<Category?>
    {
        public Guid CategoryId { get; set; }
    }
}

