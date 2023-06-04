using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Market.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Market.WebApi.Middleware;

public class JwtBearerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtBearerMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            AttachUserToContext(context, userService, token);

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSecurityKey"] ?? "123456789ABCDEFG"); // min 16 characters
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var username = jwtToken.Claims.First(x => x.Type == "username").Value;

            context.Items["User"] = userService.GetUserByUserName(username);
        }
        catch (Exception ex)
        {
            // todo: log exception
        }
    }
}