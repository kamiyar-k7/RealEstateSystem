
using Application.Dtos.BlogDtos;
using AutoMapper;
using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;

namespace Application.Services.BlogServices;

public class BlogCategoryServices : IBlogCategoryServices
{

    #region Ctor

    private readonly IMapper _mapper;
	private readonly IBlogCategoryRepository _repository;

    public BlogCategoryServices(IMapper mapper ,IBlogCategoryRepository repository )
    {
        _mapper = mapper;
        _repository = repository;
    }
    #endregion

    #region General

    public async Task AddNewBlogCategoryAsync(BlogCategoryDto categoryDto)
    {
        BlogCategoryEntity categoryEntity = new()
        {
            Name = categoryDto.Name,
        };
       
        await _repository.AddNewBlogCategoryAsync(categoryEntity);
    }


    public async Task<BlogCategoryDto> GetBlogCategoryByIdAsync(Guid id)
    {
     BlogCategoryEntity categoryEntity = await _repository.GetBlogCategoryByIdAsync(id);
        
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


    public async Task<List<BlogCategoryDto>> GetListOfBlogCategoriesAsync()
    {
          List<BlogCategoryEntity> categoryEntities = await _repository.GetListOfBlogCategoriesAsync();


        List<BlogCategoryDto> dto = _mapper.Map<List<BlogCategoryDto>>(categoryEntities);


        return dto;
           
    }
 
    public async Task UpdateBlogCategoryAsync(BlogCategoryDto blogCategory)
    {

        BlogCategoryEntity blogCategoryEntity = new()
        {
            Name = blogCategory.Name,
        };

        await _repository.UpdateBlogCategoryAsync(blogCategoryEntity);
    }

    public async Task DeleteBlogCategoryAsync(Guid id)
    {
        await _repository.DeleteBlogCategoryAsync(id);
    }

    #endregion

}
