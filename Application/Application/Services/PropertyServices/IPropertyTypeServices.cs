

using Application.Dtos.PropertyDtos;


namespace Application.Services.PropertyServices;

public interface IPropertyTypeServices
{
    Task AddNewPropertyTypeAsync(PropertyTypeDto typeDto);


    Task<PropertyTypeDto> GetPropertyTypeByIdAsync(Guid id);


    Task<List<PropertyTypeDto>> GetListOfPropertyTypesAsync();


    Task UpdatePropertTypeAsync(PropertyTypeDto typeDto);


    Task DeletePropertyTypeAsync(Guid id);
  
}
