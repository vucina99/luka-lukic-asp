using Application.Dto;
using Application.UseCase.Commands.Authors;
using Application.UseCase.Queries;
using Application.UseCase.Queries.Authors;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public AuthorsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        public IActionResult Get([FromServices] IGetAuthorsQuery query, [FromQuery] BasePagedSearch? dto)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromServices] IGetSingleAutorQuery query,[FromRoute]int id)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        [HttpPost]
        public IActionResult Post([FromServices] ICreateAuthorCommand command, [FromBody] AuthorsDto dto)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] AuthorsDto dto, [FromServices] IUpdateAuthorsCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] IDeleteAuthorCommand command, int id)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
