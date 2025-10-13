

using Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.AppDbContext;

public class RealEstateDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}
