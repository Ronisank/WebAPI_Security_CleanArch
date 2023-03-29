using Application.DTOs;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("api/autenticar")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] EmployeeDto dto)
        {
            return await _authenticationService.AuthenticateUser(dto);
        }
    }
}
