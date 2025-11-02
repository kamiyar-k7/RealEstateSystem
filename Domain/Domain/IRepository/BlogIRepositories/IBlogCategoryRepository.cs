
using Domain.Entities.Blog;

namespace Domain.IRepository.BlogIRepositories;

public interface IBlogCategoryRepository
{

    Task AddNewBlogCategoryAsync(BlogCategoryEntity blogCategory);

    Task<BlogCategoryEntity> GetBlogCategoryByIdAsync(Guid id);

    Task<List<BlogCategoryEntity>> GetListOfBlogCategoriesAsync();

    Task UpdateBlogCategoryAsync(BlogCategoryEntity blogCategory);

    Task DeleteBlogCategoryAsync(Guid id);


}
