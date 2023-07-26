using System;
using MediatR;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Categories
{
    public record AddCategoryCommand() : IRequest<Guid>
    {
        public AddCategory Category { get; set; }
    }
}

