

using Application.Dtos.LcoationDtos;
using Domain.Entities.Location;
using Domain.IRepository.LocationIRepositories;

namespace Application.Services.ProvinceServices;

public class ProvinceServices : IProvinceServices
{
    #region Ctor

    private readonly IProvinceRepository _ProvinceRepository;

    public ProvinceServices(IProvinceRepository ProvinceRepository)
    {
        _ProvinceRepository = ProvinceRepository;
    }


    #endregion


    public async Task<ProvinceDto> GetProvinceById(Guid id)
    {
        var entity = await _ProvinceRepository.GetProvinceByIdAsync(id);

        if (entity == null)
        {
            throw new Exception("Province Not Found");
        }

        ProvinceDto ProvinceDto = new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };

        return ProvinceDto;

    }

    public async Task<List<ProvinceDto>> GetListOfProvinces()
    {
        var entities = await _ProvinceRepository.GetListOfProvincesAsync();

        List<ProvinceDto> cities = new();

        foreach (var Province in entities)
        {
            ProvinceDto mappedProvince = new()
            {
                Id = Province.Id,
                Name = Province.Name
               
            };

            cities.Add(mappedProvince);
        }

        return cities;


    }

    public async Task AddProvince(ProvinceDto ProvinceDto)
    {

        ProvinceEntity ProvinceEntity = new()
        {
            Name = ProvinceDto.Name,
            
        };

        await _ProvinceRepository.AddNewProvinceAsync(ProvinceEntity);


    }


    public async Task UpdateProvince(ProvinceDto ProvinceDto)
    {

        var entity = await _ProvinceRepository.GetProvinceByIdAsync(ProvinceDto.Id);


        entity.Name = ProvinceDto.Name;
        


        await _ProvinceRepository.UpdateProvinceAsync(entity);



    }

    public async Task DeleteProvince(ProvinceDto ProvinceDto)
    {

        ProvinceEntity entity = new()
        {
            Id = ProvinceDto.Id,
        };

        await _ProvinceRepository.DeleteProvince(entity);

    }

}
