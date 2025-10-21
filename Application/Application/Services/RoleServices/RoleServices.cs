
using Application.Dtos;
using Domain.Entities.Identity;
using Domain.IRepository;


namespace Application.Services.RoleServices;

public class RoleServices : IRoleServices
{

    #region ctor
    private readonly IRoleRepository _repository;

    public RoleServices(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task AddRole(RoleDto role)
    {

        ApplicationRole mappedRole = new ApplicationRole()
        {
            Name = role.Name,
            NormalizedName = role.NormalizedName,
        };


        await _repository.AddRole(mappedRole);

    }


    public async Task<RoleDto> GetRoleByIdAsync(long id)
    {
        var role = await _repository.GetRoleById(id);

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

        RoleDto mappedRole = new()
        {
            Name = role.Name,
            NormalizedName = role.NormalizedName
        };

        return mappedRole;
    }


    public async Task<List<RoleDto>> GetRolesAsync()
    {
        var roles = await _repository.GetListOfRoles();

        if(roles.Count == 0 || roles == null)
        {
            throw new Exception("No Role Found");
        }


        List<RoleDto> rolesDto = new();


        foreach (var role in roles) 
        {

            RoleDto mappedRole = new()
            {

                Id = role.Id,
                Name = role.Name,
                NormalizedName = role.NormalizedName

            };

            rolesDto.Add(mappedRole);


        }

        return rolesDto;
    }


    public async Task UpdateRoleAsync(RoleDto roledto)
    {

        ApplicationRole mappedRole = new()
        {
            Id = roledto.Id,
            Name = roledto.Name,
            NormalizedName = roledto.NormalizedName
        };

        await _repository.UpdateRole(mappedRole);

    }
    public async Task DeleteRoleAsync(long id)
    {
        var role = await _repository.GetRoleById(id);

        if (role == null)
        {
            throw new Exception("Role Not Found");
        }

      await  _repository.RemoveRole(role);


    }



 
    #endregion

  

}
