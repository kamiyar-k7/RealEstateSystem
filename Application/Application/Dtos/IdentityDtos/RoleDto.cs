namespace Application.Dtos.IdentityDtos;

public sealed record RoleDto
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string  NormalizedName { get; set; }
 
}
