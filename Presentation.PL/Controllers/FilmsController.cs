using Application.Dto;
using Application.UseCase.Commands.Films;
using Application.UseCase.Queries.Films;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilmsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private IEnumerable<string> SupportedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };

        public FilmsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IGeFilmQuery query, [FromQuery] BasePagedSearch dto)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IFindFilmQuery query,[FromRoute] int id)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateFilmApiDto dto,[FromServices] ICreateFilmCommand command)
        {
            UploadPhoto(dto);
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromForm] UpdateFilmDto dto, [FromServices] IUpdateFilmCommand command)
        {
            dto.Id = id;
            UploadPhoto(dto);
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id, [FromServices] IDeleteFilmCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
        private void UploadPhoto(CreateFilmApiDto dto)
        {
            if (dto.File != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.File.FileName);
                if (!SupportedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Invalid File Extension.");
                }
                if(dto.File.Length > 6291456)
                {
                    throw new InvalidOperationException("File is to large. (max 6mb)");
                }
                var newFileName = guid + extension;
                var path = Path.Combine("wwwroot", "Images", newFileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.File.CopyTo(fileStream);
                }
                dto.PathName = newFileName;
            }
        }

    }
}
