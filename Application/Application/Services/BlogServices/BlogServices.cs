using Application.Dtos.BlogDtos;
using AutoMapper;
using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;

namespace Application.Services.BlogServices;

public class BlogServices : IBlogServices
{

    #region Ctor
    private readonly IMapper _mapper;
    private readonly IBlogRepository _blogRepository;

    public BlogServices(IMapper mapper,IBlogRepository blogRepository)
    {
        _mapper = mapper;
        _blogRepository = blogRepository;
    }

    #endregion

    #region General

    public async Task<BlogDto> GetBlogByIdAsync(Guid Id)
    {
        BlogEntity blog = await _blogRepository.GetBlogByIdAsync(Id);

        if (blog == null)
        {
            throw new Exception("Blog Not Found");
        }


        BlogDto dto = _mapper.Map<BlogDto>(blog);

        return dto;
    }

    public async Task<List<BlogDto>> GetListOfBlogsAsync(string search, int pageNumber, int pageSize)
    {



        List<BlogEntity> blogs = await _blogRepository.GetListOfBlogsAsync(search, pageNumber, pageSize);


        List<BlogDto> blogDtos = _mapper.Map<List<BlogDto>>(blogs);

        return blogDtos;

    }


    public async Task AddNewBlogAsync(BlogDto blogDto)
    {


        BlogEntity blog= _mapper.Map<BlogEntity>(blogDto);

        await _blogRepository.AddBlogAsync(blog);

    }

    public async Task UpdateBlogAsync(BlogDto blogDto)
    {
        var blog = await _blogRepository.GetBlogByIdAsync(blogDto.Id);

        if (blog == null)
        {
            throw new Exception("Blog Not Found");
        }

        blog.Title = blogDto.Title;
        blog.Description = blogDto.Description;
        blog.ImageUrl = blogDto.ImageUrl;

        await _blogRepository.UpdateBlogAsync(blog);

    }

    public async Task DeleteBlogAsync(Guid id)
    {
        await _blogRepository.DeleteBlogAsync(id);

    }

    public async Task SoftDeleteBlogAsync(Guid id)
    {
        var blog = await _blogRepository.GetBlogByIdAsync(id);

        blog.IsDeleted = true;

        await _blogRepository.UpdateBlogAsync(blog);
    }

    #endregion


    public async Task<List<BlogDto>> GetListOfBlogsForAdminAsync(string search, int pageNumber, int pageSize)
    {


        List<BlogEntity> blogs = await _blogRepository.GetListOfBlogsForAdminAsync(search, pageNumber, pageSize);

        List<BlogDto> blogDtos = _mapper.Map<List<BlogDto>>(blogs);

        return blogDtos;

    }
}
