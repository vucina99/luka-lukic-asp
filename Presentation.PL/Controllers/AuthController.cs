using Application.Dto;
using Application.UseCase.Commands;
using Implementation.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.PL.Auth;

namespace Presentation.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JwtManager _manager;
        private UseCaseHandler _handler;
        public AuthController(JwtManager manager, UseCaseHandler handler)
        {
            _manager = manager;
            _handler = handler;
        }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserDto dto, [FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost("token")]
        public IActionResult Token([FromBody] GenereteTokenDto dto)
        {
            try
            {
                var token = _manager.MakeToken(dto.Email, dto.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        public class GenereteTokenDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
