


namespace Application.Dtos.PropertyDtos;

public sealed record PropertyImageDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }

    public Guid PropertyId { get; set; }
 
}
