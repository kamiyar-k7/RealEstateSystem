

using Application.DataBaseContextInterface;
using Application.Services.Interface;
using Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implemented;

public class RoleServices : IRoleServices
{

    #region ctor
    private readonly IRealEstateDataBaseContext _dbcontext;
    public RoleServices(IRealEstateDataBaseContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task AddRole(ApplicationRole role)
    {
        await _dbcontext.Roles.AddAsync(role);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(int id)
    {
        var role = await _dbcontext.Roles.FirstOrDefaultAsync(r => r.Id == id);

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        _dbcontext.Roles.Remove(role);
        await _dbcontext.SaveChangesAsync();

    }

    public async Task<ApplicationRole> GetRoleByIdAsync(int id)
    {
        var role = await _dbcontext.Roles.FirstOrDefaultAsync(r => r.Id == id);
        if (role == null)
        {
            throw new Exception("Role Noy Found");
        }
        return role;
    }

    public async Task<List<ApplicationRole>> GetRolesAsync()
    {
        return await _dbcontext.Roles.ToListAsync();
    }

    public async Task UpdateRoleAsync(ApplicationRole role)
    {
       _dbcontext.Roles.Entry(role).State = EntityState.Modified;
       

        await _dbcontext.SaveChangesAsync();
    }
    #endregion

    #region General

    #endregion

}
