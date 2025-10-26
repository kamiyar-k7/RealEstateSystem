
using Domain.Entities.Identity;

namespace Domain.Entities.Blog;

public class BlogEntity : BaseEntity, IDeleteEntity
{

    public string Title { get; set; }

    public string Description { get; set; }

    public string Summery { get; set; }

    public string AuthorName { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsDeleted { get; set; }


    #region Rels

    public Guid CategoryId { get; set; }
    public BlogCategoryEntity Category { get; set; }


    public Guid AuthorId { get; set; }
    public ApplicationUser Author { get; set; }
   

    #endregion

}
