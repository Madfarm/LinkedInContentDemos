using AuthAPI.Models.Dtos;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto request)
        {
            var errorMessage = await _authService.Register(request);

            if (!string.IsNullOrEmpty(errorMessage)) 
            {
                _response.IsSuccessful = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var loginResponse = await _authService.Login(request);

            if (loginResponse.User == null)
            {
                _response.IsSuccessful = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;

            return Ok(_response);
        }
    }
}
