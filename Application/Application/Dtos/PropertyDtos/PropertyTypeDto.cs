
namespace Application.Dtos.PropertyDtos;

public class PropertyTypeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<PropertyDto> Properties { get; set; } = new();


}
