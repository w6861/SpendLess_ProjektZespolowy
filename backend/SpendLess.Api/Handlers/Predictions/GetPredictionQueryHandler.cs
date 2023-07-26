using MediatR;
using SpendLess.Api.Queries.Predictions;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Predictions
{
    public class GetPredictionQueryHandler : IRequestHandler<GetPredictionQuery, Prediction>
    {
        private readonly IPredictionsRepository _predictionsRepository;

        public GetPredictionQueryHandler(IPredictionsRepository predictionsRepository)
        {
            _predictionsRepository = predictionsRepository;
        }

        public async Task<Prediction> Handle(GetPredictionQuery request, CancellationToken cancellationToken)
        {
            return await _predictionsRepository.GetPrediction();
        }
    }
}
