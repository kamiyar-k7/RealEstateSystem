
namespace Application.Dtos.PropertyDtos;

public sealed record PropertyDto
{
    public Guid Id { get; set; }

    public DateTime CreateAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }


    public Guid OwnerId { get; set; }
    public string OwnerFullName { get; set; }


    public List<PropertyImageDto> PropertyImages { get; set; } = new();


    public Guid PropertyTypeId { get; set; }
    public string PropertyTypeName { get; set; }
 

    public Guid CityId { get; set; }
    public string CityName { get; set; }
  

    public Guid provinceId { get; set; }
    public string ProvinceName { get; set; }
   

 


}
