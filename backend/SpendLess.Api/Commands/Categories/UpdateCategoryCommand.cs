using System;
using MediatR;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Categories
{
    public record UpdateCategoryCommand() : IRequest<bool>
    {
        public UpdateCategory Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}

