using System;
using MediatR;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Categories
{
    public record GetAllCategoriesQuery : IRequest<IList<Category>>
    {

    }
}

