using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.IRepository.IdentityIRepositories;

public interface IUserRepository
{
    Task SaveChangesAsync();

    Task<ApplicationUser> GetUserByIdAsync(Guid id);

    Task<List<ApplicationUser>> GetListOfUsersAsync();

    Task AddUserAsync(ApplicationUser user);

    Task UpdateUserAsync(ApplicationUser user);

    Task RemoveUserAsync(Guid id);

}
