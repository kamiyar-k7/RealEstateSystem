using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.RoleServices;

public class RoleServices : IRoleServices
{

    #region ctor
   
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleServices( RoleManager<ApplicationRole> roleManager)
    {
     
        _roleManager = roleManager;
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


        await _roleManager.CreateAsync(mappedRole);

    }


    public async Task<RoleDto> GetRoleByIdAsync(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        RoleDto mappedRole = new()
        {
            Id = role.Id,
            Name = role.Name,
            NormalizedName = role.NormalizedName
        };

        return mappedRole;
    }


    public async Task<List<RoleDto>> GetRolesAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();

        if (roles.Count == 0 || !roles.Any())
        {
            throw new Exception("No Role Found");
        }


      

        var rolesdto = roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name,
            NormalizedName = r.NormalizedName
        }).ToList();


        return rolesdto;
    }


    public async Task UpdateRoleAsync(RoleDto roledto)
    {

        ApplicationRole mappedRole = new()
        {
            Id = roledto.Id,
            Name = roledto.Name,
            NormalizedName = roledto.NormalizedName
        };

        await _roleManager.UpdateAsync(mappedRole);

    }


    public async Task DeleteRoleAsync(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        await _roleManager.DeleteAsync(role);


    }

    #endregion


    #region Users Roles


    //public async Task<List<RoleDto>> GetUserRoles(Guid userId)
    //{

    //    var UserRoles = await _repository.GetUserRolesWithDetails(userId);

    //    var rolesDto = UserRoles.Select(role => new RoleDto
    //    {
    //        Id = role.Id,
    //        Name = role.Name,
    //        NormalizedName = role.NormalizedName

    //    }).ToList();

    //    return rolesDto;

    //}



    //public async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
    //{
    //    if (!await _userManager.IsInRoleAsync(user, roleName))
    //    {
    //        await _userManager.AddToRoleAsync(user, roleName);
    //    }
    //}


    //public async Task UpdateUserRoles(Guid userId, List<Guid> rolesIds)
    //{
    //    //get user roles
    //    var userroles = await _repository.GetUserSelectedRoles(userId);

    //    // delete user roles
    //    if ( userroles.Any())
    //    {
    //        _repository.RemoveUserRoles(userroles);
    //    }


    //    //add new roles

    //    var newRoles = rolesIds.Select(r => new IdentityUserRole<Guid>
    //    {
    //        RoleId = r,
    //        UserId = userId

    //    }).ToList();

    //    await _repository.AddNewUserRoles(newRoles);


    //    //save
    //    await _repository.SaveChangesAsync();

    //}


    #endregion


}
