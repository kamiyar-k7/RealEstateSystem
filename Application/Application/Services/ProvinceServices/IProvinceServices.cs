
using Application.Dtos.LcoationDtos;

namespace Application.Services.ProvinceServices;

public interface IProvinceServices
{
    Task<ProvinceDto> GetProvinceById(Guid id);


    Task<List<ProvinceDto>> GetListOfProvinces();


    Task AddProvince(ProvinceDto ProvinceDto);



    Task UpdateProvince(ProvinceDto ProvinceDto);

    Task DeleteProvince(ProvinceDto ProvinceDto);
}
