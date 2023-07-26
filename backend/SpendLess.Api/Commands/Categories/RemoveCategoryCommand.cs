using System;
using MediatR;
using SpendLess.Domain;

namespace SpendLess.Api.Queries.Categories
{
    public record RemoveCategoryCommand() : IRequest<Unit>
    {
        public Guid CategoryId { get; set; }
    }
}

