using Market.DomainEntities.Entities;
using Market.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase 
{
    public User CurrentUser { get; }

    public BaseController()
    {
        CurrentUser = (User)HttpContext.Items["User"]!; // checked is AuthorizeAttribute
    }
}