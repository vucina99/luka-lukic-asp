using Application.Dto;
using Application.UseCase.Commands.Orders;
using Application.UseCase.Queries.Orders;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet("user/{id}")]
        public IActionResult Get(int id, [FromQuery] OrderBasePagedSearch dto, [FromServices] IGetUsersOrderQuery query)
        {
            dto.UserId = id;
            return Ok(_handler.HandleQuery(query, dto));
        }
        [HttpPost]
        public IActionResult Post([FromBody] MakeOrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);

        }
    }
}
