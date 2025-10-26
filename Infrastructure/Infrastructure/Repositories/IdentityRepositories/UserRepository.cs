﻿
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;
using Infrastructure.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.IdentityRepositories;

public class UserRepository : IUserRepository
{

    #region Ctor

    private readonly RealEstateDataBaseContext _context;
    public UserRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region General


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ApplicationUser> GetUserById(Guid id)
    {
        return await _context.Users.FindAsync(id);

    }

    public async Task<List<ApplicationUser>> GetListOfUsers()
    {
        return await _context.Users.ToListAsync() ?? new List<ApplicationUser>();
    }

    public async Task AddUser(ApplicationUser user)
    {

        await _context.Users.AddAsync(user);
        await SaveChangesAsync();
    }

    public async Task UpdateUser(ApplicationUser user)
    {
        _context.Update(user);
        await SaveChangesAsync();
    }

    public async Task RemoveUser(Guid id)
    {

        await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }


    #endregion

    
}
