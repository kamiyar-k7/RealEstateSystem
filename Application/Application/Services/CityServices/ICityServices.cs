

using Application.Dtos.LcoationDtos;
using Domain.Entities.Location;
using Domain.IRepository;

namespace Application.Services.CityServices;

public interface ICityServices
{

    Task<CityDto> GetCityById(Guid id);


    Task<List<CityDto>> GetListOfCities();


    Task AddCity(CityDto cityDto);



    Task UpdateCity(CityDto cityDto);

    Task DeleteCity(CityDto cityDto);


}
