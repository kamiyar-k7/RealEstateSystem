
using Domain.Entities.Identity;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Domain.IRepository;

namespace Infrastructure.Repositories;

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


    public async Task<ApplicationRole> GetRoleById(long id)
    {
      return  await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
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
}
