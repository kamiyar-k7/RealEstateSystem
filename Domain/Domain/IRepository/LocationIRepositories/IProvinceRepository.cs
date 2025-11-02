using Domain.Entities.Location;

namespace Domain.IRepository.LocationIRepositories;

public interface IProvinceRepository
{
    Task<ProvinceEntity> GetProvinceByIdAsync(Guid id);
    Task<List<ProvinceEntity>> GetListOfProvincesAsync();
    Task AddNewProvinceAsync(ProvinceEntity Province);
    Task UpdateProvinceAsync(ProvinceEntity Province);
    Task DeleteProvinceAsync(ProvinceEntity Province);

}
