

namespace Domain.Entities.Blog;

public class BlogCategoryEntity  
{

    public Guid Id { get; set; }
    public string Name { get; set; }


    #region Rels


    public List<BlogEntity> Blogs { get; set; } = new();

    #endregion




}
