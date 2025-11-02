using Domain.Entities.Location;

namespace Domain.IRepository.LocationIRepositories;

public interface ICityRepository
{
    Task<CityEntity> GetCityByIdAsync(Guid id);
    Task<List<CityEntity>> GetListOfCitiesAsync(string search, int pageNumber, int pageSize);
    Task AddNewCityAsync(CityEntity city);
    Task UpdateCityAsync(CityEntity city);
    Task DeleteCityAsync(CityEntity city);

}
