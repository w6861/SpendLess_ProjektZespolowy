using MediatR;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Queries.Predictions
{
    public record GetPredictionQuery : IRequest<Prediction>
    {
    }
}
