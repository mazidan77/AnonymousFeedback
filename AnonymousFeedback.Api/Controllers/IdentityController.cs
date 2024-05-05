using AnonymousFeedback.Application.Dtos.IdentityDto;
using AnonymousFeedback.Domian.IManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;

        public IdentityController(IIdentityManager identityManager)
        {
            _identityManager=identityManager;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await _identityManager.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id = user.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _identityManager.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
}
