using Domain.Entities.Property;
using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string? ProfilPictureUrl { get; set; }


    #region Rels

    
 
    public List<PropertyEntity> Properties { get; set; } = new(); 


    #endregion
}

