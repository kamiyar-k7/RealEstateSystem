
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task SaveChangesAsync();

    Task<ApplicationUser> GetUserById(long id);

    Task<List<ApplicationUser>> GetListOfUsers();

    Task AddUser(ApplicationUser user);

    Task UpdateUser(ApplicationUser user);

    Task RemoveUser(ApplicationUser user);

}
