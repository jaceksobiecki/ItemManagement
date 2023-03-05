using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Application.Queries.GetColors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Return all records from Colors dictionary.
        /// </summary>
        /// <param name="date">2022-01-01</param>
        [HttpGet("{date?}")]
        public async Task<ActionResult<List<ColorDto>>> Get([FromRoute] DateTime? date)
        {
            var result = await _mediator.Send(new GetColorsQuery() { Date = date });
            return Ok(result);
        }
    }
}
