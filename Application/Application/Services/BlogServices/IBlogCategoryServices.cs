

using Application.Dtos.BlogDtos;
using Domain.Entities.Blog;

namespace Application.Services.BlogServices;

public interface IBlogCategoryServices
{
    Task AddNewBlogCategory(BlogCategoryDto categoryDto);

    Task<BlogCategoryDto> GetBlogCategoryById(Guid id);

    Task<List<BlogCategoryDto>> GetListOfBlogCategories();

    Task UpdateBlogCategory(BlogCategoryDto categoryDto);

    Task DeleteBlogCategory(Guid id);
}
