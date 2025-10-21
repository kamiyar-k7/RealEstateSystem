namespace Domain.Entities.Property;

public class PropertyImageEntity 
{

    public Guid Id { get; set; }
    public string ImageUrl { get; set; }

    public Guid PropertyId { get; set; }

    #region Rels

    public PropertyEntity Property { get; set; }
    #endregion

}
