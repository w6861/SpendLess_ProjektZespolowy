using MediatR;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Stats
{
    public record GetStatsQuery : IRequest<Statistics>
    {
        public GetStats Query { get; set; }
    }
}

