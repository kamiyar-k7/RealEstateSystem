
using Application.Dtos.LcoationDtos;

namespace Application.Services.ProvinceServices;

public interface IProvinceServices
{
    Task<ProvinceDto> GetProvinceByIdAsync(Guid id);


    Task<List<ProvinceDto>> GetListOfProvincesAsync();


    Task AddProvinceAsync(ProvinceDto ProvinceDto);



    Task UpdateProvinceAsync(ProvinceDto ProvinceDto);

    Task DeleteProvinceAsync(ProvinceDto ProvinceDto);
}
