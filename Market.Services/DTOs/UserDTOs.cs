using Market.DomainEntities.Entities;

namespace Market.Services.DTOs;

public record UserDto(string UserName, string FullName, string Email, ICollection<Product> Products)
{
    public User ToUser()
    {
        return new User
        {
            UserName = UserName,
            FullName = FullName,
            Email = Email,
            SellingProducts = Products
        };
    }
}

public record UserCreateDto(string UserName, string FullName, string Password, string Email)
{
    public User ToUser()
    {
        return new User
        {
            UserName = UserName,
            FullName = FullName,
            Password = Password,
            Email = Email
        };
    }
}

public record UserUpdateDto(string UserName, string FullName, string Password)
{
    public User ToUser()
    {
        return new User
        {
            UserName = UserName,
            FullName = FullName,
            Password = Password
        };
    }
};

public record UserLoginDto(string UserName, string Password)
{
    public User ToUser()
    {
        return new User
        {
            UserName = UserName,
            Password = Password
        };
    }
}