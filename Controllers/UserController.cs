
//using Dmart_web.Core.DTOs;
//using Dmart_web.Core.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;


//namespace Dmart_web.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]

//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
//        {
//            var result = await _userService.RegisterAsync(dto);
//            return Ok(result);
//        }

//        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
//        [HttpGet("login")]
//        public IActionResult Login()
//        {
//            var username = User.Identity?.Name;
//            var role = User.FindFirst(ClaimTypes.Role)?.Value;
//            return Ok($"Welcome {username}, your role is {role}");
//        }
//    }
//}

using Dmart_web.Core.DTOs;
using Dmart_web.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Dmart_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                var result = await _userService.RegisterAsync(dto);
                if (result == "User registered successfully")
                {
                    return Ok(new { message = result });
                }
                return BadRequest(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Registration failed: {ex.Message}" });
            }
        }

        //[Authorize(AuthenticationSchemes = "BasicAuthentication")]
        //[HttpGet("login")]
        //public IActionResult Login()
        //{
        //    var username = User.Identity?.Name;
        //    var role = User.FindFirst(ClaimTypes.Role)?.Value;
        //    return Ok(new { message = $"Welcome {username}, your role is {role}" });
        //}

        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpGet("login")]
        public IActionResult Login()
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                message = $"Welcome {username}, your role is {role}",
                userId = userIdClaim,
                username = username,
                role = role
            });
        }

        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                userId = userId,
                username = username,
                role = role
            });
        }
    }
}