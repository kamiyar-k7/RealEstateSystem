

using Application.Dtos.LcoationDtos;
using Domain.Entities.Location;
using Domain.IRepository;

namespace Application.Services.CityServices;

public interface ICityServices
{

    Task<CityDto> GetCityByIdAsync(Guid id);


    Task<List<CityDto>> GetListOfCitiesAsync(string search, int pageNumber, int pageSize);


    Task AddCityAsync(CityDto cityDto);



    Task UpdateCityAsync(CityDto cityDto);

    Task DeleteCityAsync(CityDto cityDto);


}
