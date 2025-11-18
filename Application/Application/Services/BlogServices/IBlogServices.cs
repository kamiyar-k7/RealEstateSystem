

using Application.Dtos.BlogDtos;


namespace Application.Services.BlogServices;

public interface IBlogServices
{

    Task<BlogDto> GetBlogByIdAsync(Guid Id);

    Task<List<BlogDto>> GetListOfBlogsAsync(string search, int pageNumber, int pageSize);

    Task AddNewBlogAsync(BlogDto blogDto);

    Task UpdateBlogAsync(BlogDto blogDto);

    Task DeleteBlogAsync(Guid id);

    Task SoftDeleteBlogAsync(Guid id);

    Task<List<BlogDto>> GetListOfBlogsForAdminAsync(string search, int pageNumber, int pageSize);

}
