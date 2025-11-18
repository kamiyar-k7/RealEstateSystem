

using Application.Dtos.LcoationDtos;
using AutoMapper;
using Domain.Entities.Location;
using Domain.IRepository.LocationIRepositories;

namespace Application.Services.ProvinceServices;

public class ProvinceServices : IProvinceServices
{
    #region Ctor

    private readonly IMapper _mapper;
    private readonly IProvinceRepository _ProvinceRepository;

    public ProvinceServices(IProvinceRepository ProvinceRepository, IMapper mapper)
    {
        _ProvinceRepository = ProvinceRepository;
        _mapper = mapper;
    }


    #endregion


    public async Task<ProvinceDto> GetProvinceByIdAsync(Guid id)
    {
        ProvinceEntity entity = await _ProvinceRepository.GetProvinceByIdAsync(id);

        if (entity == null)
        {
            throw new Exception("Province Not Found");
        }

        ProvinceDto ProvinceDto = new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };

        return ProvinceDto;

    }

    public async Task<List<ProvinceDto>> GetListOfProvincesAsync()
    {
        List<ProvinceEntity> entities = await _ProvinceRepository.GetListOfProvincesAsync();

        List<ProvinceDto> cities = _mapper.Map<List<ProvinceDto>>(entities);

        return cities;


    }

    public async Task AddProvinceAsync(ProvinceDto ProvinceDto)
    {

        ProvinceEntity ProvinceEntity = new()
        {
            Name = ProvinceDto.Name,
            
        };

        await _ProvinceRepository.AddNewProvinceAsync(ProvinceEntity);


    }


    public async Task UpdateProvinceAsync(ProvinceDto ProvinceDto)
    {

        var entity = await _ProvinceRepository.GetProvinceByIdAsync(ProvinceDto.Id);


        entity.Name = ProvinceDto.Name;
        


        await _ProvinceRepository.UpdateProvinceAsync(entity);



    }

    public async Task DeleteProvinceAsync(ProvinceDto ProvinceDto)
    {

        ProvinceEntity entity = new()
        {
            Id = ProvinceDto.Id,
        };

        await _ProvinceRepository.DeleteProvinceAsync(entity);

    }

}
