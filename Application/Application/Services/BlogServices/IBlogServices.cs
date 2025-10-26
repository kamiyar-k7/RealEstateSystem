

using Application.Dtos.BlogDtos;


namespace Application.Services.BlogServices;

public interface IBlogServices
{

    Task<BlogDto> GetBlogById(Guid Id);

    Task<List<BlogDto>> GetListOfBlogs(string search, int pageNumber, int pageSize);

    Task AddNewBlog(BlogDto blogDto);

    Task UpdateBlog(BlogDto blogDto);

    Task DeleteBlog(Guid id);

    Task SoftDeleteBlog(Guid id);

    Task<List<BlogDto>> GetListOfBlogsForAdmin(string search, int pageNumber, int pageSize);

}
