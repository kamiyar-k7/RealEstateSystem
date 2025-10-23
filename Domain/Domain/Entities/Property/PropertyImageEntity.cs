namespace Domain.Entities.Property;

public class PropertyImageEntity 
{

    public Guid Id { get; set; }
    public string ImageUrl { get; set; }


    #region Rels
    public Guid PropertyId { get; set; }
    public PropertyEntity Property { get; set; }
    #endregion

}
