using Market.Services.DTOs;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("Login")]
    public async Task<JsonResult> Login(UserLoginDto userLoginDto)
    {
        var token = await _authorizationService.AuthorizeAsync(userLoginDto);

        return string.IsNullOrEmpty(token)
            ? new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized }
            : new JsonResult(new { token }) { StatusCode = StatusCodes.Status200OK};
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserCreateDto userCreateDto)
    {
        var isSuccess = await _authorizationService.RegisterAsync(userCreateDto);

        return isSuccess
            ? Ok(isSuccess)
            : Problem(statusCode: StatusCodes.Status503ServiceUnavailable);
    }
}