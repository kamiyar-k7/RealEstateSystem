
using Domain.Entities.Identity;


namespace Domain.IRepository;

public interface IRoleRepository
{


  

    Task<ApplicationRole> GetRoleById(long id);

    Task<List<ApplicationRole>> GetListOfRoles();

    Task AddRole(ApplicationRole role);

    Task UpdateRole(ApplicationRole role);

    Task RemoveRole(ApplicationRole role);

}
