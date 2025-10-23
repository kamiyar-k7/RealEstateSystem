

namespace Domain.Entities.Property;

public class PropertyTypeEntity : BaseEntity
{


    public string Name { get; set; }

    

    #region Rels

    public List<PropertyEntity> Properties { get; set; }

    #endregion

}
