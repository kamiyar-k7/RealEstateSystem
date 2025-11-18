

using Application.Dtos.PropertyDtos;
using AutoMapper;
using Domain.Entities.Property;
using Domain.IRepository.PropertyIRepsitories;

namespace Application.Services.PropertyServices;

public class PropertyTypeServices : IPropertyTypeServices
{
    #region Ctor

    private readonly IMapper _mapper;
    private readonly IPropertyTypeRepository _typeRepository;

    public PropertyTypeServices(IPropertyTypeRepository typeRepository, IMapper mapper)
    {
        _typeRepository = typeRepository;
        _mapper = mapper;
    }

    #endregion

    #region General

    public async Task AddNewPropertyTypeAsync(PropertyTypeDto typeDto)
    {

        PropertyTypeEntity entity = new()
        {
            Id = typeDto.Id,
            Name = typeDto.Name,

        };

        await _typeRepository.AddNewPropertyTypeAsync(entity);

    }

    public async Task<PropertyTypeDto> GetPropertyTypeByIdAsync(Guid id)
    {

        var entity = await _typeRepository.GetPropertyTypeByIdAsync(id);

        if (entity == null)
        {
            throw new Exception("Property Type Not Found");
        }


        PropertyTypeDto dto = new()
        {
            Id = id,
            Name = entity.Name,

        };

        return dto;

    }

    public async Task<List<PropertyTypeDto>> GetListOfPropertyTypesAsync()
    {

        var propertyTypes = await _typeRepository.GetListOFPropertyTypesAsync();

        List<PropertyTypeDto> pTypeDtos = _mapper.Map<List<PropertyTypeDto>>(propertyTypes);
        
        return pTypeDtos;
    }

    public async Task UpdatePropertTypeAsync(PropertyTypeDto typeDto)
    {
        PropertyTypeEntity typeEntity = new()
        {
            Name = typeDto.Name,
        };

        await _typeRepository.UpdatePropertyAsync(typeEntity);

    }

    public async Task DeletePropertyTypeAsync(Guid id)
    {
        await _typeRepository.DeletePropertyAsync(id);

    }

    #endregion
}
