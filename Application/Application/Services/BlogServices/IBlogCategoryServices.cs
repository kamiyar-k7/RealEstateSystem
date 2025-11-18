

using Application.Dtos.BlogDtos;
using Domain.Entities.Blog;

namespace Application.Services.BlogServices;

public interface IBlogCategoryServices
{
    Task AddNewBlogCategoryAsync(BlogCategoryDto categoryDto);

    Task<BlogCategoryDto> GetBlogCategoryByIdAsync(Guid id);

    Task<List<BlogCategoryDto>> GetListOfBlogCategoriesAsync();

    Task UpdateBlogCategoryAsync(BlogCategoryDto categoryDto);

    Task DeleteBlogCategoryAsync(Guid id);
}
