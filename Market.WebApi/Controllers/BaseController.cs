using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase 
{
    public BaseController()
    {
        // todo: Initialize User context
    }
}