using Domain.Entities.Blog;


namespace Domain.IRepository.BlogIRepositories;

public interface IBlogRepository
{

    Task<BlogEntity> GetBlogById(Guid id);

    Task<List<BlogEntity>> GetListOfBlogs(string search, int pageNumber, int pageSize);

    Task AddBlog(BlogEntity blog);

    Task DeleteBlog(Guid id);

    Task UpdateBlog(BlogEntity blog);

    Task<List<BlogEntity>> GetListOfBlogsForAdmin(string search, int pageNumber, int pageSize);
}
