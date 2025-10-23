
using Domain.Entities.Identity;

namespace Domain.Entities.Blog;

public class BlogEntity : BaseEntity
{


    public string Title { get; set; }

    public string Description { get; set; }

    public string AuthorName { get; set; }

    public string imageUrl { get; set; }




    #region Rels
    public Guid AuthorId { get; set; }

    public ApplicationUser Author { get; set; }

    #endregion

}
