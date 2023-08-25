using Application;
using Application.Dto;
using Application.Logging;
using Application.UseCase.Commands;
using Application.UseCase.Queries.Users;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private UseCaseHandler _handler;

        public UserController(UseCaseHandler handler, IApplicationUser user)
        {
            _handler = handler;
            _user = user;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_user);

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody] UpdateUserUseCaseDto dto,
            [FromServices] IUpdateUserUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpGet("logs")]
        public IActionResult GetLogs([FromQuery] UseCaseLogSearch dto, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

    }
}
