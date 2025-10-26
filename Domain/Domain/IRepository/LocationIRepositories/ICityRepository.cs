using Domain.Entities.Location;

namespace Domain.IRepository.LocationIRepositories;

public interface ICityRepository
{
    Task<CityEntity> GetCityById(Guid id);
    Task<List<CityEntity>> GetListOfCities();
    Task AddNewCity(CityEntity city);
    Task UpdateCity(CityEntity city);
    Task DeleteCity(CityEntity city);

}
