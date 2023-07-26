using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpendLess.Api.Queries;
using SpendLess.Api.Queries.Raports;
using SpendLess.Domain;

namespace SpendLess.Api.Controllers
{
    [Route("api/[controller]")]
    public class RaportsController : Controller
    {
        private readonly IMediator _mediator;

        public RaportsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> RaportAsync(GetRaport request)
        {
            return Ok(await _mediator.Send(new GetRaportQuery { Query = request }));
        }
    }
}

