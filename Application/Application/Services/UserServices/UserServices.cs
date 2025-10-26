using Application.Dtos.IdentityDtos;
using Domain.Entities.Identity;
using Domain.IRepository.IdentityIRepositories;


namespace Application.Services.UserServices;

public class UserServices : IUserServices
{

    #region Ctor

    private readonly IUserRepository _userRepository;
    public UserServices(IUserRepository userRepository)
    {

        _userRepository = userRepository;
    }

    #endregion

    #region General

    public async Task AddUser(UserDto userDto)
    {


        ApplicationUser user = new()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            FullName = userDto.FullName,
            PhoneNumber = userDto.PhoneNumber,
            ProfilPictureUrl = userDto.ProfilPictureUrl,
        };

        await _userRepository.AddUser(user);


    }


    public async Task<List<UserDto>> GetUsersAsync()
    {

        var users = await _userRepository.GetListOfUsers();

        if (users.Count == 0 || users == null)
        {
            throw new Exception("No User Found");


        }

        List<UserDto> usersDto = new List<UserDto>();




        foreach (var user in users)
        {


            UserDto mappedUser = new UserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                ProfilPictureUrl = user.ProfilPictureUrl,
            };

            usersDto.Add(mappedUser);

        }

        return usersDto;


    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);



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
        
        await _userRepository.RemoveUser(id);


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

        await _userRepository.UpdateUser(mappeduser);


    }
    #endregion


    
}
