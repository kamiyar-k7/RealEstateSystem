namespace Domain.Entities.ProperetyEntities;

public class FacilityEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PropertyEntity> Properties { get; set; }
}



