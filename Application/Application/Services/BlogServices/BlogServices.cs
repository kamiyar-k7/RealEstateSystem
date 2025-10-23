using Application.Dtos;
using Domain.Entities.Blog;
using Domain.IRepository;

namespace Application.Services.BlogServices;

public class BlogServices : IBlogServices
{

    #region Ctor

    private readonly IBlogRepository _blogRepository;

    public BlogServices(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    #endregion

    #region General

    public async Task<BlogDto> GetBlogById(Guid Id)
    {
        var blog = await _blogRepository.GetBlogById(Id);

        if (blog == null)
        {
            throw new Exception("Blog Not Found");
        }

        BlogDto dto = new()
        {
            Id = Id,
            AuthorName = blog.AuthorName,
            CreateAt = blog.CreateAt,
            Description = blog.Description,
            Title = blog.Title,
            IsDeleted = blog.IsDeleted,
        };

        return dto;
    }

    public async Task<List<BlogDto>> BlogDtos()
    {

        var blogs = await _blogRepository.GetListOfBlogs();

        List<BlogDto> blogsDto = new();

        foreach (var blog in blogs)
        {

            BlogDto mappedlog = new()
            {
                Id = blog.Id,
                AuthorName = blog.AuthorName,
                CreateAt = blog.CreateAt,
                Description = blog.Description,
                IsDeleted = blog.IsDeleted,
                Title = blog.Title,
            };

            blogsDto.Add(mappedlog);
        }

        return blogsDto;

    }


    public async Task AddNewBlog(BlogDto blogDto)
    {

        BlogEntity blog = new()
        {
            Title = blogDto.Title,
            AuthorName = blogDto.AuthorName,
            Description = blogDto.Description,
            AuthorId = blogDto.AuthorId,

        };

        await _blogRepository.AddBlog(blog);

    }

    public async Task UpdateBlog(BlogDto blogDto)
    {
        var blog = await _blogRepository.GetBlogById(blogDto.Id);

        if (blog == null)
        {
            throw new Exception("Blog Not Found");
        }

        blog.Title = blogDto.Title;
        blog.Description = blogDto.Description;
        blog.imageUrl = blogDto.imageUrl;

        await _blogRepository.UpdateBlog(blog);

    }

    public async Task DeleteBlog(Guid Id) 
    {
        var blog = await _blogRepository.GetBlogById(Id);

        if (blog == null)
        {
            throw new Exception("Blog Not Found");
        }

        await _blogRepository.DeleteBlog(blog);

    }

    #endregion

}
