

using Application.Dtos.PropertyDtos;


namespace Application.Services.PropertyServices;

public interface IPropertyTypeServices
{
    Task AddNewPropertyType(PropertyTypeDto typeDto);


    Task<PropertyTypeDto> GetPropertyTypeById(Guid id);


    Task<List<PropertyTypeDto>> GetListOfPropertyTypes();


    Task UpdatePropertType(PropertyTypeDto typeDto);


    Task DeletePropertyType(Guid id);
  
}
