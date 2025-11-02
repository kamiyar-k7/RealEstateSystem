

using Application.Dtos.PropertyDtos;
using Domain.Entities.Property;
using Domain.IRepository.PropertyIRepsitories;

namespace Application.Services.PropertyServices;

public class PropertyTypeServices : IPropertyTypeServices
{
    #region Ctor

    private readonly IPropertyTypeRepository _typeRepository;

    public PropertyTypeServices(IPropertyTypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    #endregion

    #region General

    public async Task AddNewPropertyType(PropertyTypeDto typeDto)
    {

        PropertyTypeEntity entity = new()
        {
            Id = typeDto.Id,
            Name = typeDto.Name,

        };

        await _typeRepository.AddNewPropertyTypeAsync(entity);

    }

    public async Task<PropertyTypeDto> GetPropertyTypeById(Guid id)
    {

        var entity = await _typeRepository.GetPropertyTypeByIdAsync(id);

        if (entity == null)
        {
            throw new Exception("Property Type Not Found");
        }


        // Use AutoMapper
        PropertyTypeDto dto = new()
        {
            Id = id,
            Name = entity.Name,
            Properties = entity.Properties.Select(t => new PropertyDto
            {

                Id = t.Id,

            }).ToList()

        };

        return dto;

    }

    public async Task<List<PropertyTypeDto>> GetListOfPropertyTypes()
    {

        var propertyTypes = await _typeRepository.GetListOFPropertyTypesAsync();

        List<PropertyTypeDto> dtoList = new List<PropertyTypeDto>();

        foreach (var type in propertyTypes)
        {
            PropertyTypeDto mappedType = new()
            {
                Id = type.Id,
                Name = type.Name,

            };

            dtoList.Add(mappedType);
        }

        return dtoList;
    }

    public async Task UpdatePropertType(PropertyTypeDto typeDto)
    {
        PropertyTypeEntity typeEntity = new()
        {
            Name = typeDto.Name,
        };

        await _typeRepository.UpdatePropertyAsync(typeEntity);

    }

    public async Task DeletePropertyType(Guid id)
    {
        await _typeRepository.DeletePropertyAsync(id);

    }

    #endregion
}
