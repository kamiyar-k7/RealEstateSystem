namespace Application.Dtos.BlogDtos;

public sealed record BlogDto
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public string? ImageUrl { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public Guid BlogCategoryId { get; set; }
    public string CategoryName { get; set; }
}
