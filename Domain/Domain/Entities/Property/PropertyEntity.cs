using Domain.Entities.Identity;
using Domain.Entities.Location;

namespace Domain.Entities.Property;

public class PropertyEntity : BaseEntity , IDeleteEntity
{

    // info
    public string Title { get; set; }

    public string Description { get; set; }


    // for map view
    public double Latitude { get; set; }
    public double Longitude { get; set; }



    public bool IsDeleted { get ; set ; }


    #region rels

    // user releation
    public Guid OwnerId { get; set; }
    public string OwnerFullName { get; set; }
    public ApplicationUser Owner { get; set; }


    public List<PropertyImageEntity> PropertyImages { get; set; } = new();


    // type relation
    public Guid PropertyTypeId { get; set; }
    public string PropertyTypeName{ get; set; }
    public PropertyTypeEntity PropertyType { get; set; }


    // city and province  relations
    public Guid CityId { get; set; }
    public CityEntity City { get; set; }


    public Guid ProvinceId { get; set; }
    public ProvinceEntity Province { get; set; }
  

    #endregion



}








