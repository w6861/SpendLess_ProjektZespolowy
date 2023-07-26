using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpendLess.Api.Queries.Predictions;

namespace SpendLess.Api.Controllers
{
    [Route("api/[controller]")]
    public class PredictionsController : Controller
    {
        private readonly IMediator _mediator;

        public PredictionsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> RaportAsync()
        {
            return Ok(await _mediator.Send(new GetPredictionQuery { }));
        }
    }
}

