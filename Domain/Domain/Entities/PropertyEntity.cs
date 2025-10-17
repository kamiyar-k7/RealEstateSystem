using Domain.Identity.Entities;

namespace Domain.Entities.ProperetyEntities;

public class PropertyEntity : BaseEntity
{

    //Base info
    public string Title { get; set; }

    public string Description { get; set; }

    public PropertyType Type { get; set; }


    // for map view
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    #region rels

    public List<PropertyImageEntity> PropertyImages { get; set; } = new();
    public ApplicationUser ApplicationUser { get; set; }

    #endregion



    //Owner Details
    //public guid ownerid
    //Public string OwnerName
    //Public long OwnerPhone
}


public enum PropertyType
{
    Apartamant = 0,
    Villa = 1,
    Office = 2,
    Shop = 3,
    Land = 4,
    Penthouse = 5 ,

}





