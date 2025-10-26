using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;

namespace Application.Services.RoleServices;

public interface IRoleServices
{
    Task<List<RoleDto>> GetRolesAsync();

    Task<RoleDto> GetRoleByIdAsync(Guid id);

    Task AddRole(RoleDto role);

    Task DeleteRoleAsync(Guid id);

    Task UpdateRoleAsync(RoleDto role);

}
