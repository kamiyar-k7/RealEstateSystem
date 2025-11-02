
using Application.Dtos.BlogDtos;
using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;

namespace Application.Services.BlogServices;

public class BlogCategoryServices : IBlogCategoryServices
{

	#region Ctor

	private readonly IBlogCategoryRepository _repository;

    public BlogCategoryServices(IBlogCategoryRepository repository)
    {
        _repository = repository;
    }
    #endregion

    #region General

    public async Task AddNewBlogCategory(BlogCategoryDto categoryDto)
    {
        BlogCategoryEntity categoryEntity = new()
        {
            Name = categoryDto.Name,
        };
       
        await _repository.AddNewBlogCategoryAsync(categoryEntity);
    }


    public async Task<BlogCategoryDto> GetBlogCategoryById(Guid id)
    {
     var categoryEntity = await _repository.GetBlogCategoryByIdAsync(id);
        
        if (categoryEntity == null) 
        {
            throw new Exception("Blog Category Not Found");
        }

        BlogCategoryDto CategoryDto = new()
        {
            Id = id,
            Name = categoryEntity.Name,
        };

        return CategoryDto;
    }


    public async Task<List<BlogCategoryDto>> GetListOfBlogCategories()
    {
          var categoryEntities = await _repository.GetListOfBlogCategoriesAsync();

        List<BlogCategoryDto> dtolist = new();

        foreach (var category in categoryEntities)
        {

            BlogCategoryDto mappedCategory = new()
            {
                Id=category.Id,
                Name = category.Name,
            };

            dtolist.Add(mappedCategory);
        }
        return dtolist;
           
    }
 
    public async Task UpdateBlogCategory(BlogCategoryDto blogCategory)
    {

        BlogCategoryEntity blogCategoryEntity = new()
        {
            Name = blogCategory.Name,
        };

        await _repository.UpdateBlogCategoryAsync(blogCategoryEntity);
    }

    public async Task DeleteBlogCategory(Guid id)
    {
        await _repository.DeleteBlogCategoryAsync(id);
    }

    #endregion

}
