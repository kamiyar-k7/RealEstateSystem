namespace Application.Dtos.IdentityDtos;



public sealed record UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfilPictureUrl { get; set; }

    


    #region rels

    public List<RoleDto> Roles { get; set; }

    #endregion

}
