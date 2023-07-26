using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpendLess.Api.Queries;
using SpendLess.Api.Queries.Categories;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllCategoriesQuery()));
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuery { CategoryId = categoryId }));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategory category)
        {
            return Ok(await _mediator.Send(new AddCategoryCommand { Category = category }));
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] UpdateCategory category)
        {
            return Ok(await _mediator.Send(new UpdateCategoryCommand { CategoryId = categoryId, Category = category }));
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> RemoveCategory(Guid categoryId)
        {
            return Ok(await _mediator.Send(new RemoveCategoryCommand { CategoryId = categoryId }));
        }
    }
}

