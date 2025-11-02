
namespace Application.Dtos.PropertyDtos;

public sealed record PropertyTypeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<PropertyDto> Properties { get; set; } = new();


}
