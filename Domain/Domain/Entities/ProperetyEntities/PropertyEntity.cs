namespace Domain.Entities.ProperetyEntities;

public class PropertyEntity
{

    public Guid Id { get; set; }


    //Base info
    public string Title { get; set; }

    public string Description { get; set; }

    public PropertyType Type { get; set; }
    public Status Status { get; set; }


    //Address
    public string Location { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    // for map view
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    // other...

    public float LandArea { get; set; }

    public float HouseArea { get; set; }

    public int Room { get; set; }

    public int BathRoom { get; set; }

    public List<FacilityEntity> Facilities { get; set; } = new();

    public int YearBuilt { get; set; }

    public List<PropertyImageEntity> PropertyImages { get; set; } = new();



    //price
    public decimal? SalePrice { get; set; }
    public decimal? RentPrice { get; set; }
    public bool IsForRent { get; set; }



    //Owner Details
    //public User Owner { get; set; }
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


public enum Status
{

    Active = 0,
    InActive = 1,

}



