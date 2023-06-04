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

    public async Task<JsonResult> Login(string userName, string password)
    {
        var token = await _authorizationService.AuthorizeAsync(userName, password);

        return string.IsNullOrEmpty(token)
            ? new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized }
            : new JsonResult(new { token }) { StatusCode = StatusCodes.Status200OK};
    }
}