

namespace Domain.Entities.Location;

public class CityEntity : BaseEntity
{

    public string Name { get; set; }


    #region Rels

    public Guid ProvinceId { get; set; }
    public ProvinceEntity Province { get; set; }


    #endregion
}
