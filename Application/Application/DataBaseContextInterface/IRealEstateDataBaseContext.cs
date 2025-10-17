
using Domain.Entities.ProperetyEntities;
using Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataBaseContextInterface;

public interface IRealEstateDataBaseContext
{
    DbSet<ApplicationUser> Users { get; set; }
    DbSet<ApplicationRole> Roles { get; set; }
    DbSet<PropertyEntity> PropertyEntitiy { get; set; }
    DbSet<PropertyImageEntity> PropertyImageEntity { get; set; }


    //
    Task SaveChangesAsync();
  
}
