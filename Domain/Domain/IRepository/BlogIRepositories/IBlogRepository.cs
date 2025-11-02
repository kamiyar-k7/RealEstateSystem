using Domain.Entities.Blog;


namespace Domain.IRepository.BlogIRepositories;

public interface IBlogRepository
{

    Task<BlogEntity> GetBlogByIdAsync(Guid id);

    Task<List<BlogEntity>> GetListOfBlogsAsync(string search, int pageNumber, int pageSize);

    Task AddBlogAsync(BlogEntity blog);

    Task DeleteBlogAsync(Guid id);

    Task UpdateBlogAsync(BlogEntity blog);

    Task<List<BlogEntity>> GetListOfBlogsForAdminAsync(string search, int pageNumber, int pageSize);
}
