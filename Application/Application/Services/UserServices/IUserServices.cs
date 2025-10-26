using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;

namespace Application.Services.UserServices;

public interface IUserServices
{

    Task<List<UserDto>> GetUsersAsync();

    Task<UserDto> GetUserByIdAsync(Guid id);

    Task AddUser(UserDto user);

    Task DeleteUserAsync(Guid  id);

    Task UpdateUserAsync(UserDto user);

}
