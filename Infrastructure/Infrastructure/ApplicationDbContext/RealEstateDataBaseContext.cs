﻿

using Domain.Entities.Blog;
using Domain.Entities.Identity;
using Domain.Entities.Location;
using Domain.Entities.Property;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext;

public class RealEstateDataBaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public RealEstateDataBaseContext(DbContextOptions<RealEstateDataBaseContext> options) : base(options)
    {

    }

    // property
    public DbSet<PropertyEntity> Property { get; set; }
    public DbSet<PropertyImageEntity> PropertyImage { get; set; }
    public DbSet<PropertyTypeEntity> PropertyType { get; set; }


    //location
    public DbSet<CityEntity> City { get; set; }
    public DbSet<ProvinceEntity> Province { get; set; }


    // blog
    public DbSet<BlogEntity> Blog { get; set; }
    public DbSet<BlogCategoryEntity> BlogCategory {  get; set; }


}
