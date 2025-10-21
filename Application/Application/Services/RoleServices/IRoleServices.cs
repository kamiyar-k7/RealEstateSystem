using Application.Dtos;
using Domain.Entities.Identity;

namespace Application.Services.RoleServices;

public interface IRoleServices
{
    Task<List<RoleDto>> GetRolesAsync();

    Task<RoleDto> GetRoleByIdAsync(long id);

    Task AddRole(RoleDto role);

    Task DeleteRoleAsync(long id);

    Task UpdateRoleAsync(RoleDto role);

}
