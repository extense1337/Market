using Market.DomainEntities.Entities;
using Market.Services.DTOs;
using Market.Services.Interfaces;
using Market.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public User CurrentUser { get; set; }

    public UserController(IUserService userService)
    {
        _userService = userService;

        CurrentUser = (User)HttpContext.Items["User"]!; // checked is AuthorizeAttribute
    }

    [Authorize] // todo: admin role
    [HttpGet("{userName}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByUserName(string userName)
    {
        var user = await _userService.GetUserByUserName(userName);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [Authorize] // todo: admin role
    [HttpPost("CreateUser")]
    public async Task<bool> CreateUser(UserCreateDto userCreateDto)
    {
        return await _userService.CreateUser(userCreateDto);
    }

    [Authorize]
    [HttpPost("UpdateUser")]
    public async Task<bool> UpdateUser(UserUpdateDto userUpdateDto)
    {
        if (CurrentUser.UserName != userUpdateDto.UserName) // todo: if not admin role
        {
            return false; // todo: fix after adding common result types
        }

        return await _userService.UpdateUser(userUpdateDto);
    }
}