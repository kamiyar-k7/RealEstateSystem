using Application.Dtos.BlogDtos;
using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;

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
        var blog = await _blogRepository.GetBlogByIdAsync(Id);

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
            Summary = blog.Summery,
            BlogCategoryId = blog.CategoryId,
            CategoryName = blog.Category.Name
        };

        return dto;
    }

    public async Task<List<BlogDto>> GetListOfBlogs(string search, int pageNumber, int pageSize)
    {



        var blogs = await _blogRepository.GetListOfBlogsAsync(search, pageNumber, pageSize);

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
                AuthorId = blog.AuthorId,
                ImageUrl = blog.ImageUrl
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
            Summery = blogDto.Summary,
            CategoryId = blogDto.BlogCategoryId


        };

        await _blogRepository.AddBlogAsync(blog);

    }

    public async Task UpdateBlog(BlogDto blogDto)
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

    public async Task DeleteBlog(Guid id)
    {
        await _blogRepository.DeleteBlogAsync(id);

    }

    public async Task SoftDeleteBlog(Guid id)
    {
        var blog = await _blogRepository.GetBlogByIdAsync(id);

        blog.IsDeleted = true;

        await _blogRepository.UpdateBlogAsync(blog);
    }

    #endregion


    public async Task<List<BlogDto>> GetListOfBlogsForAdmin(string search, int pageNumber, int pageSize)
    {


        var blogs = await _blogRepository.GetListOfBlogsForAdminAsync(search, pageNumber, pageSize);

        List<BlogDto> blogsDto = new();

        foreach (var blog in blogs)
        {

            BlogDto mappedlog = new()
            {
                Id = blog.Id,
                AuthorName = blog.AuthorName,
                CreateAt = blog.CreateAt,
                Description = blog.Description,
                Summary = blog.Summery,
                IsDeleted = blog.IsDeleted,
                Title = blog.Title,
                AuthorId = blog.AuthorId,
                ImageUrl = blog.ImageUrl,
                BlogCategoryId = blog.CategoryId,
                CategoryName = blog.Category.Name

            };

            blogsDto.Add(mappedlog);
        }

        return blogsDto;

    }
}
