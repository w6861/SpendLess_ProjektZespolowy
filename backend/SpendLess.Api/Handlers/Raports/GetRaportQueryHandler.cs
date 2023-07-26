using MediatR;
using SpendLess.Api.Queries.Raports;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Handlers.Raports
{
    public class GetRaportQueryHandler : IRequestHandler<GetRaportQuery, Raport>
    {
        private readonly IRaportsRepository _raportRepository;

        public GetRaportQueryHandler(IRaportsRepository raportRepository)
        {
            _raportRepository = raportRepository;
        }

        public async Task<Raport> Handle(GetRaportQuery request, CancellationToken cancellationToken)
        {
            return await _raportRepository.GetRaport(request.Query);
        }
    }
}

