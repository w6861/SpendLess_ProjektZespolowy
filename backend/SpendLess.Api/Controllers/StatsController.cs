using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpendLess.Api.Queries.Stats;
using SpendLess.Domain;

namespace SpendLess.Api.Controllers
{
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly IMediator _mediator;

        public StatsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetStatsAsync()
        {
            return Ok(await _mediator.Send(new GetStatsQuery()));
        }
    }
}

