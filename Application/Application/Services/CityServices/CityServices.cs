
using Application.Dtos.LcoationDtos;
using AutoMapper;
using Domain.Entities.Location;
using Domain.IRepository.LocationIRepositories;

namespace Application.Services.CityServices;

public class CityServices : ICityServices
{

    #region Ctor

    private readonly  IMapper _mapper;
    private readonly ICityRepository _cityRepository;

    public CityServices(IMapper mapper,ICityRepository cityRepository)
    {
        _mapper = mapper;
        _cityRepository = cityRepository;
    }


    #endregion


    public async Task<CityDto> GetCityByIdAsync(Guid id)
    {
        CityEntity entity = await _cityRepository.GetCityByIdAsync(id);

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

    public async Task<List<CityDto>> GetListOfCitiesAsync( string search , int pageNumber, int pageSize)
    {
        List<CityEntity> entities = await _cityRepository.GetListOfCitiesAsync(search , pageNumber , pageSize);



        List<CityDto> cities = _mapper.Map<List<CityDto>>(entities);  

   

        return cities;


    }

    public async Task AddCityAsync(CityDto cityDto)
    {

        CityEntity cityEntity = new()
        {
            Name = cityDto.Name,
            
            ProvinceId = cityDto.ProvinceId,
        };

        await _cityRepository.AddNewCityAsync(cityEntity);


    }


    public async Task UpdateCityAsync(CityDto cityDto) 
    {

        CityEntity entity = await _cityRepository.GetCityByIdAsync(cityDto.Id);


        entity.Name = cityDto.Name;       
      
        entity.ProvinceId = cityDto.ProvinceId;
        

        await _cityRepository.UpdateCityAsync(entity);



    }

    public async Task DeleteCityAsync(CityDto cityDto) 
    {

        CityEntity entity = new()
        {
            Id = cityDto.Id,
        };

        await _cityRepository.DeleteCityAsync(entity);   

    }

}
