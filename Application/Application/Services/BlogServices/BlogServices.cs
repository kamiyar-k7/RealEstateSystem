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
            Summery = blog.Summery,
            BlogCategoryId = blog.CategoryId,
            CategoryName = blog.Category.Name
        };

        return dto;
    }

    public async Task<List<BlogDto>> GetListOfBlogs(string search, int pageNumber, int pageSize)
    {



        var blogs = await _blogRepository.GetListOfBlogs(search, pageNumber, pageSize);

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
                imageUrl = blog.ImageUrl
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
            Summery = blogDto.Summery,
            CategoryId = blogDto.BlogCategoryId


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
        blog.ImageUrl = blogDto.imageUrl;

        await _blogRepository.UpdateBlog(blog);

    }

    public async Task DeleteBlog(Guid id)
    {
        await _blogRepository.DeleteBlog(id);

    }

    public async Task SoftDeleteBlog(Guid id)
    {
        var blog = await _blogRepository.GetBlogById(id);

        blog.IsDeleted = true;

        await _blogRepository.UpdateBlog(blog);
    }

    #endregion


    public async Task<List<BlogDto>> GetListOfBlogsForAdmin(string search, int pageNumber, int pageSize)
    {


        var blogs = await _blogRepository.GetListOfBlogsForAdmin(search, pageNumber, pageSize);

        List<BlogDto> blogsDto = new();

        foreach (var blog in blogs)
        {

            BlogDto mappedlog = new()
            {
                Id = blog.Id,
                AuthorName = blog.AuthorName,
                CreateAt = blog.CreateAt,
                Description = blog.Description,
                Summery = blog.Summery,
                IsDeleted = blog.IsDeleted,
                Title = blog.Title,
                AuthorId = blog.AuthorId,
                imageUrl = blog.ImageUrl,
                BlogCategoryId = blog.CategoryId,
                CategoryName = blog.Category.Name

            };

            blogsDto.Add(mappedlog);
        }

        return blogsDto;

    }
}
