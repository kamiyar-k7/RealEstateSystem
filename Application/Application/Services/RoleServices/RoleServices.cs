using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;
using Microsoft.AspNetCore.Identity;


namespace Application.Services.RoleServices;

public class RoleServices : IRoleServices
{

    #region ctor
    private readonly IRoleRepository _repository;

    public RoleServices(IRoleRepository repository)
    {
        _repository = repository;
    }
    #endregion

    #region General


    public async Task AddRole(RoleDto role)
    {

        ApplicationRole mappedRole = new ApplicationRole()
        {
            Name = role.Name,
            NormalizedName = role.NormalizedName,
        };


        await _repository.AddRole(mappedRole);

    }


    public async Task<RoleDto> GetRoleByIdAsync(Guid id)
    {
        var role = await _repository.GetRoleById(id);

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        RoleDto mappedRole = new()
        {
            Name = role.Name,
            NormalizedName = role.NormalizedName
        };

        return mappedRole;
    }


    public async Task<List<RoleDto>> GetRolesAsync()
    {
        var roles = await _repository.GetListOfRoles();

        if (roles.Count == 0 || roles == null)
        {
            throw new Exception("No Role Found");
        }


        List<RoleDto> rolesDto = new();


        foreach (var role in roles)
        {

            RoleDto mappedRole = new()
            {

                Id = role.Id,
                Name = role.Name,
                NormalizedName = role.NormalizedName

            };

            rolesDto.Add(mappedRole);


        }

        return rolesDto;
    }


    public async Task UpdateRoleAsync(RoleDto roledto)
    {

        ApplicationRole mappedRole = new()
        {
            Id = roledto.Id,
            Name = roledto.Name,
            NormalizedName = roledto.NormalizedName
        };

        await _repository.UpdateRole(mappedRole);

    }


    public async Task DeleteRoleAsync(Guid id)
    {
        var role = await _repository.GetRoleById(id);

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        await _repository.RemoveRole(role);


    }

    #endregion


    #region Users Roles


    public async Task<List<RoleDto>> GetUserRoles(Guid userId)
    {

        var UserRoles = await _repository.GetUserRolesWithDetails(userId);

        var rolesDto = UserRoles.Select(role => new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            NormalizedName = role.NormalizedName

        }).ToList();

        return rolesDto;

    }


    public async Task UpdateUserRoles(Guid userId, List<Guid> rolesIds)
    {
        //get user roles
        var userroles = await _repository.GetUserSelectedRoles(userId);

        // delete user roles
        if ( userroles.Any())
        {
            _repository.RemoveUserRoles(userroles);
        }


        //add new roles

        var newRoles = rolesIds.Select(r => new IdentityUserRole<Guid>
        {
            RoleId = r,
            UserId = userId

        }).ToList();

        await _repository.AddNewUserRoles(newRoles);


        //save
        await _repository.SaveChangesAsync();

    }


    #endregion


}
