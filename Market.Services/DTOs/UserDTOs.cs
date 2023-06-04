using Market.DomainEntities.Entities;

namespace Market.Services.DTOs;

public record UserDto(string UserName, string FullName, string Email, ICollection<Product> Products);

public record UserCreateDto(string UserName, string FullName, string Password, string Email);

public record UserUpdateDto(string UserName, string FullName, string Password);