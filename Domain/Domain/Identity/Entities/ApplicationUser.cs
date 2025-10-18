using Microsoft.AspNetCore.Identity;


namespace Domain.Identity.Entities;

public class ApplicationUser:IdentityUser<long>
{
   public string FullName { get; set; }
}
