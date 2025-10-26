using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.IRepository.IdentityIRepositories;

public interface IUserRepository
{
    Task SaveChangesAsync();

    Task<ApplicationUser> GetUserById(Guid id);

    Task<List<ApplicationUser>> GetListOfUsers();

    Task AddUser(ApplicationUser user);

    Task UpdateUser(ApplicationUser user);

    Task RemoveUser(Guid id);

}
