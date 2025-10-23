
using Domain.Entities.Property;


namespace Domain.IRepository;

public interface IPropertyRepository
{

    Task<PropertyEntity> GetPropertyById(Guid id);


    Task<List<PropertyEntity>> GetListOfProperties();



    Task<List<PropertyEntity>> GetPropertiesByType(Guid propertyTypeId);



    Task AddNewProperty(PropertyEntity property);



    Task UpdateProperty(PropertyEntity property);


    #region Delete Property

    Task<PropertyEntity> FindProperty(Guid propertyId);

    Task DeleteProperty(PropertyEntity property);

    #endregion
}
