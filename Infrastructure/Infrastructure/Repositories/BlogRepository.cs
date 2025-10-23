

using Domain.Entities.Blog;
using Domain.IRepository;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BlogRepository : IBlogRepository
{

    #region ctor

    private readonly RealEstateDataBaseContext _context;
    public BlogRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region General


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


    public async Task<BlogEntity> GetBlogById(Guid id)
    {
        return await _context.Blog.FindAsync(id);
    }

    public async Task<List<BlogEntity>> GetListOfBlogs()
    {
        // gets all even deleted
        return await _context.Blog.ToListAsync();
    }

    public async Task AddBlog(BlogEntity blog)
    {
        await _context.Blog.AddAsync(blog);
        await SaveChangesAsync();

    }

    public async Task DeleteBlog(BlogEntity blog)
    {
        

        blog.IsDeleted = true;

        await SaveChangesAsync();
    }

    public async Task UpdateBlog(BlogEntity blog) 
    {
        _context.Update(blog);
        await SaveChangesAsync();
    }

    #endregion

}
