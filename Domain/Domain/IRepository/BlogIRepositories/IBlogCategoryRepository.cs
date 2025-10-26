
using Domain.Entities.Blog;

namespace Domain.IRepository.BlogIRepositories;

public interface IBlogCategoryRepository
{

    Task AddNewBlogCategory(BlogCategoryEntity blogCategory);

    Task<BlogCategoryEntity> GetBlogCategoryById(Guid id);

    Task<List<BlogCategoryEntity>> GetListOfBlogCategories();

    Task UpdateBlogCategory(BlogCategoryEntity blogCategory);

    Task DeleteBlogCategory(Guid id);


}
