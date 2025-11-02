

using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BlogRepositories;

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


    public async Task<BlogEntity> GetBlogByIdAsync(Guid id)
    {
        return await _context.Blog.FindAsync(id);
    }

    public async Task<List<BlogEntity>> GetListOfBlogsAsync(string search, int pageNumber, int pageSize)
    {

        var query = _context.Blog.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(b => b.Title.Contains(search));

        var result = await query
            .Where(b => b.IsDeleted == false)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return result;

    }



    public async Task AddBlogAsync(BlogEntity blog)
    {
        await _context.Blog.AddAsync(blog);
        await SaveChangesAsync();

    }

    public async Task DeleteBlogAsync(Guid id)
    {
        await _context.Blog.Where(x => x.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    public async Task UpdateBlogAsync(BlogEntity blog)
    {
        _context.Update(blog);
        await SaveChangesAsync();
    }

    #endregion


    public async Task<List<BlogEntity>> GetListOfBlogsForAdminAsync(string search, int pageNumber, int pageSize)
    {


        // gets all even deleted
        var query = _context.Blog.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(b => b.Title.Contains(search));

        var result = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return result;

    }



}
