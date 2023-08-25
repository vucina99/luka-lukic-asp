using Application.Dto;
using Application.UseCase.Commands.Comments;
using Application.UseCase.Queries.Comments;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CommentsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet("film/{id}")]
        public IActionResult Get(int id, [FromServices] IFindFilmCommentsQuery query)
        {

            return Ok(_handler.HandleQuery(query, id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto dto, [FromServices] ICreateCommentCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Post(int id, [FromServices] IDeleteCommentCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
