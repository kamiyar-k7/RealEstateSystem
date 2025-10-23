
namespace Domain.Entities.Location;

public class ProvinceEntity 
{
    public Guid Id { get; set; }
    public string Name { get; set; }


    #region rels

    public List<CityEntity> Cities { get; set; } = new();

    #endregion

}
