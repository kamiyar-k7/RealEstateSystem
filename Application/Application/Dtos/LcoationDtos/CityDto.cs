namespace Application.Dtos.LcoationDtos;

public class CityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
    public string ProvinceName { get; set; }
}
