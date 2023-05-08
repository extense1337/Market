using Market.Services.DTOs;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userName}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByUserName(string userName)
    {
        var user = await _userService.GetUserByUserName(userName);

        if (user is null) throw new Exception("Пользователь с таким логином не найден!");

        return Ok(user);
    }

    [HttpPost("CreateUser")]
    public async Task<bool> CreateUser(UserCreateDto userCreateDto)
    {
        return await _userService.CreateUser(userCreateDto);
    }

    [HttpPost("UpdateUser")]
    public async Task<bool> UpdateUser(UserUpdateDto userUpdateDto)
    {
        return await _userService.UpdateUser(userUpdateDto);
    }
}