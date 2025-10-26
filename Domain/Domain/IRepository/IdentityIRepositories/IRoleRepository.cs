using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Domain.IRepository.IdentityIRepositories;

public interface IRoleRepository
{



    #region General
    Task SaveChangesAsync();

    Task<ApplicationRole> GetRoleById(Guid id);

    Task<List<ApplicationRole>> GetListOfRoles();

    Task AddRole(ApplicationRole role);

    Task UpdateRole(ApplicationRole role);

    Task RemoveRole(ApplicationRole role);
    #endregion

    #region UserRoles

    Task<List<ApplicationRole>> GetUserRolesWithDetails(Guid userId);

    Task<List<IdentityUserRole<Guid>>> GetUserSelectedRoles(Guid userId);
    void RemoveUserRoles(List<IdentityUserRole<Guid>> selectedRoles);
    Task AddNewUserRoles(List<IdentityUserRole<Guid>> userRoles);
    #endregion

}
