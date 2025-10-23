
namespace Domain.Entities.Location;

public class ProvinceEntity : BaseEntity
{

    public string Name { get; set; }


    #region rels

    public List<CityEntity> Cities { get; set; } = new();

    #endregion

}
