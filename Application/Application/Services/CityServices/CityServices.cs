
using Application.Dtos.LcoationDtos;
using Domain.Entities.Location;
using Domain.IRepository.LocationIRepositories;

namespace Application.Services.CityServices;

public class CityServices : ICityServices
{

    #region Ctor

    private readonly ICityRepository _cityRepository;

    public CityServices(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }


    #endregion


    public async Task<CityDto> GetCityById(Guid id)
    {
        var entity = await _cityRepository.GetCityById(id);

        if (entity == null)
        {
            throw new Exception("City Not Found");
        }

        CityDto cityDto = new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };

        return cityDto;

    }

    public async Task<List<CityDto>> GetListOfCities()
    {
        var entities = await _cityRepository.GetListOfCities();

        List<CityDto> cities = new();

        foreach (var city in entities)
        {
            CityDto mappedCity = new()
            {
                Id = city.Id,
                Name = city.Name,
                ProvinceId = city.ProvinceId,
                
            };

            cities.Add(mappedCity);
        }

        return cities;


    }

    public async Task AddCity(CityDto cityDto)
    {

        CityEntity cityEntity = new()
        {
            Name = cityDto.Name,
            
            ProvinceId = cityDto.ProvinceId,
        };

        await _cityRepository.AddNewCity(cityEntity);


    }


    public async Task UpdateCity(CityDto cityDto) 
    {

        var entity = await _cityRepository.GetCityById(cityDto.Id);


        entity.Name = cityDto.Name;       
      
        entity.ProvinceId = cityDto.ProvinceId;
        

        await _cityRepository.UpdateCity(entity);



    }

    public async Task DeleteCity(CityDto cityDto) 
    {

        CityEntity entity = new()
        {
            Id = cityDto.Id,
        };

        await _cityRepository.DeleteCity(entity);   

    }

}
