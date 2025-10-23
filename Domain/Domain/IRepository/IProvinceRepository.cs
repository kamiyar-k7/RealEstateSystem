

using Domain.Entities.Location;

namespace Domain.IRepository;

public interface IProvinceRepository
{
    Task<ProvinceEntity> GetProvinceById(Guid id);
    Task<List<ProvinceEntity>> GetListOfProvinces();
    Task AddNewProvince(ProvinceEntity Province);
    Task UpdateProvince(ProvinceEntity Province);
    Task DeleteProvince(ProvinceEntity Province);

}
