

using Application.DataBaseContextInterface;
using Domain.Entities.ProperetyEntities;
using Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext;

public class RealEstateDataBaseContext:IdentityDbContext<ApplicationUser, ApplicationRole, long> , IRealEstateDataBaseContext
{
    public RealEstateDataBaseContext(DbContextOptions<RealEstateDataBaseContext> options) : base(options)
    {

    }

    public DbSet<PropertyEntity> PropertyEntitiy { get; set; }
    public DbSet<PropertyImageEntity>  PropertyImageEntity { get; set; }

    public async Task SaveChangesAsync()
    {
       await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}
