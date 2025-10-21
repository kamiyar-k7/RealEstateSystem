using Application.Dtos;
using Domain.Entities.Identity;

namespace Application.Services.UserServices;

public interface IUserServices
{

    Task<List<UserDto>> GetUsersAsync();

    Task<UserDto> GetUserByIdAsync(int id);

    Task AddUser(UserDto user);

    Task DeleteUserAsync(int id);

    Task UpdateUserAsync(UserDto user);

}
