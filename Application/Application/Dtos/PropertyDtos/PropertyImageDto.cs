
using Domain.Entities.Property;

namespace Application.Dtos.PropertyDtos;

public class PropertyImageDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }

    public Guid PropertyId { get; set; }
 
}
