
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;
using Infrastructure.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.IdentityRepositories;

public class RoleRepository : IRoleRepository
{


    #region Ctor

    private readonly RealEstateDataBaseContext _context;
    public RoleRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region General


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


    public async Task<ApplicationRole> GetRoleById(Guid id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<List<ApplicationRole>> GetListOfRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task AddRole(ApplicationRole role)
    {
        await _context.Roles.AddAsync(role);
        await SaveChangesAsync();
    }

    public async Task UpdateRole(ApplicationRole role)
    {

        _context.Update(role);
        await SaveChangesAsync();

    }

    public async Task RemoveRole(ApplicationRole role)
    {
        _context.Roles.Remove(role);
        await SaveChangesAsync();

    }


    #endregion



    #region user roles

    /// <summary>
    /// get all details of user roles like name and ...
    /// </summary>
   
    public async Task<List<ApplicationRole>> GetUserRolesWithDetails(Guid userId)
    {


        var roleIds = await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .ToListAsync();


        return await _context.Roles
            .Where(r => roleIds.Contains(r.Id))
            .ToListAsync();


    }



    /// <summary>
    /// gets only records of Selected roles for user
    /// </summary>
    public async Task<List<IdentityUserRole<Guid>>> GetUserSelectedRoles(Guid userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }

    public void RemoveUserRoles(List<IdentityUserRole<Guid>> selectedRoles)
    {
            _context.UserRoles.RemoveRange(selectedRoles);
        
    }

    public async Task AddNewUserRoles(List<IdentityUserRole<Guid>> userRoles)
    {

        await _context.UserRoles.AddRangeAsync(userRoles);
     
       

    }

    #endregion
}
