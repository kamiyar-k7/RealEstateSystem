namespace Application.Dtos.BlogDtos;

public class BlogDto
{

    public Guid Id { get; set; }

    public DateTime CreateAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Summery { get; set; }

    public string? imageUrl { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }


  
    public Guid BlogCategoryId { get; set; }
   public string CategoryName { get; set; }
   


}
