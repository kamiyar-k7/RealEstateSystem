
using Domain.Identity.Entities;

namespace Application.Services.Interface;

public interface IUserServices
{

    Task<List<ApplicationUser>> GetUsersAsync();

    Task<ApplicationUser> GetUserByIdAsync(int id);

    Task AddUser(ApplicationUser user);

    Task DeleteUserAsync(int id);

    Task UpdateUserAsync(ApplicationUser user);

}
