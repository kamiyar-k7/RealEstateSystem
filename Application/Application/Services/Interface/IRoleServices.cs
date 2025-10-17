
using Domain.Identity.Entities;

namespace Application.Services.Interface;

public interface IRoleServices
{
    Task<List<ApplicationRole>> GetRolesAsync();

    Task<ApplicationRole> GetRoleByIdAsync(int id);

    Task AddRole(ApplicationRole role);

    Task DeleteRoleAsync(int id);

    Task UpdateRoleAsync(ApplicationRole role);

}
