namespace Application.Dtos.LcoationDtos;

public sealed record CityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
    public string ProvinceName { get; set; }
}
