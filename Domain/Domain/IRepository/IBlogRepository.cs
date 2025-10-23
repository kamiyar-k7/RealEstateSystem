
using Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Domain.IRepository;

public interface IBlogRepository
{

    Task<BlogEntity> GetBlogById(Guid id);



    Task<List<BlogEntity>> GetListOfBlogs();



    Task AddBlog(BlogEntity blog);



    Task DeleteBlog(BlogEntity blog);



    Task UpdateBlog(BlogEntity blog);



}
