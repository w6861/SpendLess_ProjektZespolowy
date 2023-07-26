using MediatR;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Raports
{
    public record GetRaportQuery : IRequest<Raport>
    {
        public GetRaport Query { get; set; }
    }
}

