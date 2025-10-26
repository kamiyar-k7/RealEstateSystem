
using Domain.Entities.Property;

namespace Domain.IRepository.PropertyIRepsitories;

public interface IPropertyTypeRepository
{


    Task AddNewPropertyType(PropertyTypeEntity typeEntity);

    Task<PropertyTypeEntity> GetPropertyTypeById(Guid Id);

    Task<List<PropertyTypeEntity>> GetListOFPropertyTypes();

    Task UpdateProperty(PropertyTypeEntity propertyTypeEntity);

    Task DeleteProperty(Guid Id);


}
