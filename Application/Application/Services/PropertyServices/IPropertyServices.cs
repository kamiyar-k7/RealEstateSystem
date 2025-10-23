
using Application.Dtos.PropertyDtos;


namespace Application.Services.PropertyServices;

public interface IPropertyServices
{


    #region General

    Task<PropertyDto> GetPropertyById(Guid id);


    Task<List<PropertyDto>> GetListOfProperties();



    Task AddProperty(PropertyDto propertyDto);



    Task UpdateProperty(PropertyDto propertyDto);



    Task DeleteProperty(Guid Id);



    #endregion


    // get by type
    Task<List<PropertyDto>> GetAllProperties(Guid typeId);




}
