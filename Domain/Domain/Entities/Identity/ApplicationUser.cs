using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<long>
{
    public string FullName { get; set; }
    public string ProfilPictureUrl { get; set; }
}
