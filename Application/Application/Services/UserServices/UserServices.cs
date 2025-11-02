using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;
using Microsoft.AspNetCore.Identity;


namespace Application.Services.UserServices;

public class UserServices : IUserServices
{

    #region Ctor

    private readonly IUserRepository _userRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    public UserServices(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
    {

        _userRepository = userRepository;
        _userManager = userManager;
    }

    #endregion

    #region General

    public async Task AddUserAsync(UserDto userDto)
    {


        ApplicationUser user = new()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            FullName = userDto.FullName,
            PhoneNumber = userDto.PhoneNumber,
            ProfilPictureUrl = userDto.ProfilPictureUrl,
        };

        await _userRepository.AddUserAsync(user);


    }


    public async Task<List<UserDto>> GetUsersAsync()
    {

        List<ApplicationUser> users = await _userRepository.GetListOfUsersAsync();

        if (users.Count == 0 || users == null)
        {
            throw new Exception("No User Found");


        }


        List<UserDto> usersDto = users.Select(u => new UserDto
        {
            UserName = u.UserName,
            Email = u.Email,
            FullName = u.FullName,
            Id = u.Id,
            PhoneNumber = u.PhoneNumber,
            ProfilPictureUrl = u.ProfilPictureUrl,
        }).ToList();



        return usersDto;


    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new Exception("User Not Found");
        }

        var mappeduser = new UserDto()
        {
            Id = user.Id,
            FullName = user.FullName,
            UserName = user.PhoneNumber,
            PhoneNumber = user.PhoneNumber,
            ProfilPictureUrl = user.ProfilPictureUrl,
            Email = user.Email,
        };

        return mappeduser;
    }


    public async Task DeleteUserAsync(Guid id)
    {

        await _userRepository.RemoveUserAsync(id);


    }

    public async Task UpdateUserAsync(UserDto user)
    {

        var mappeduser = new ApplicationUser()
        {
            Id = user.Id,
            UserName = user.UserName,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfilPictureUrl = user.ProfilPictureUrl,
        };

        await _userRepository.UpdateUserAsync(mappeduser);


    }
    #endregion


    #region User Roles


    public async Task AddRolesToUserAsync(UserDto userDto)
    {

        var user = await _userManager.FindByIdAsync(userDto.Id.ToString());


        List<string> rolesName = userDto.Roles.Select(r => r.Name).ToList();


        var result = await _userManager.AddToRolesAsync(user, rolesName);


    }

    public async Task<IList<string>> GetUserRolesAsync(Guid userId)
    {

        var user = await _userManager.FindByIdAsync(userId.ToString());

        return await _userManager.GetRolesAsync(user);
    }

    public async Task RemoveUserFromRoleAsync(Guid userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        await _userManager.RemoveFromRoleAsync(user, roleName);

    }
    #endregion



}
