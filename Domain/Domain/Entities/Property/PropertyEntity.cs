using Domain.Entities.Identity;
using Domain.Entities.Location;

namespace Domain.Entities.Property;

public class PropertyEntity : BaseEntity
{

    // info
    public string Title { get; set; }

    public string Description { get; set; }


    // for map view
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    #region rels


    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }


    public List<PropertyImageEntity> PropertyImages { get; set; } = new();

    public Guid PropertyTypeId { get; set; }
    public PropertyTypeEntity PropertyType { get; set; }


    // city and province 
    public Guid CityId { get; set; }
    public CityEntity City { get; set; }


    public Guid provinceId { get; set; }
    public ProvinceEntity Province { get; set; }

    #endregion



}








