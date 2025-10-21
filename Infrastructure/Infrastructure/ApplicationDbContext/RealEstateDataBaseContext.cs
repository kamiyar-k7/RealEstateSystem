


using Domain.Entities.Identity;
using Domain.Entities.Property;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext;

public class RealEstateDataBaseContext:IdentityDbContext<ApplicationUser, ApplicationRole, long> 
{
    public RealEstateDataBaseContext(DbContextOptions<RealEstateDataBaseContext> options) : base(options)
    {

    }

    public DbSet<PropertyEntity> Property { get; set; }
    public DbSet<PropertyImageEntity>  PropertyImage { get; set; }



}
