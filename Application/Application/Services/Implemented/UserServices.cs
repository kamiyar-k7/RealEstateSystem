
using Application.DataBaseContextInterface;
using Application.Services.Interface;
using Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implemented;

public class UserServices : IUserServices
{

    #region Ctor

    private readonly IRealEstateDataBaseContext _dbContex;

    public UserServices(IRealEstateDataBaseContext dbContex)
    {
        _dbContex = dbContex;
    }

    #endregion

    #region General

    public async Task AddUser(ApplicationUser user)
    {
        await _dbContex.Users.AddAsync(user);
       await  _dbContex.SaveChangesAsync();
    }

    public async Task<List<ApplicationUser>> GetUsersAsync()
    {
        return await _dbContex.Users.ToListAsync();
    }

    public async Task<ApplicationUser> GetUserByIdAsync(int id)
    {
        var user = await _dbContex.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) 
        {
            throw new Exception("User Not Found");
        }
        
        return user;
    }


    public async Task DeleteUserAsync(int id)
    {
        var user = _dbContex.Users.FirstOrDefault(x=> x.Id == id);
        if (user == null)
        {
            throw new Exception("User Not Found");
        }

         _dbContex.Users.Remove(user);
        await _dbContex.SaveChangesAsync();

    }


  
    public async Task UpdateUserAsync(ApplicationUser user)
    {
        _dbContex.Users.Entry(user).State  = EntityState.Modified;
    
        await _dbContex.SaveChangesAsync();
    }
    #endregion
}
