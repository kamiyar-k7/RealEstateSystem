

namespace Domain.Entities.Property;

public class PropertyTypeEntity 
{

    public Guid Id { get; set; }
    public string Name { get; set; }



    #region Rels

    public List<PropertyEntity> Properties { get; set; } = new();

    #endregion

}
