using AutoMapper;
using ItemManagement.Application.Commands.AddItem;
using ItemManagement.Application.Commands.UpdateItem;
using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Application.Interfaces.Services;
using ItemManagement.Application.Queries.GetItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.OData.Query;

namespace ItemManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public ItemsController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        /// <summary>
        /// Returns all Items
        /// </summary>
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<ItemDto>>> Get()
        {
            var result = await _mediator.Send(new GetItemsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="itemDto">object</param>
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody][Required] ItemDto itemDto)
        {
            if (await _identityService.UserIsAdmin())
            {
                await _mediator.Send(new AddItemCommand() { ItemDto = itemDto });
                return Ok(new { status = "SUCCESS" });
            }
            else
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="itemDto">object</param>
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody][Required] ItemDto itemDto
            )
        {
            if (await _identityService.UserIsAdmin())
            {
                await _mediator.Send(
                new UpdateItemCommand(){ ItemDto = itemDto });

                return Ok(new { status = "SUCCESS" });
            }
            else
            {
                return Forbid();
            }
        }
    }
}
