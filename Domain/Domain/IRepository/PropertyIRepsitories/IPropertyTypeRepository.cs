
using Domain.Entities.Property;

namespace Domain.IRepository.PropertyIRepsitories;

public interface IPropertyTypeRepository
{


    Task AddNewPropertyTypeAsync(PropertyTypeEntity typeEntity);

    Task<PropertyTypeEntity> GetPropertyTypeByIdAsync(Guid Id);

    Task<List<PropertyTypeEntity>> GetListOFPropertyTypesAsync();

    Task UpdatePropertyAsync(PropertyTypeEntity propertyTypeEntity);

    Task DeletePropertyAsync(Guid Id);


}
