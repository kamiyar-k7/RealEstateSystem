﻿
namespace Application.Dtos;



public class UserDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfilPictureUrl { get; set; }
}
