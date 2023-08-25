using Application.Dto;
using Application.UseCase.Commands.Categories;
using Application.UseCase.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        public IActionResult GetAll([FromServices] IGetCategoriesQuery query, [FromQuery] BasePagedSearch dto)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromServices] IFindCategoryQuery query, int id)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromServices] ICreateCategoryCommand command, [FromBody] CategoryDto dto)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromServices] IUpdateCategoryCommand command, [FromBody] CategoryDto dto)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }

    }
}
