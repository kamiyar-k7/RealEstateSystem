
using Domain.Entities.Blog;
using Domain.IRepository.BlogIRepositories;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BlogRepositories;

public class BlogCategoryRepository : IBlogCategoryRepository
{

    #region Ctor

    private readonly RealEstateDataBaseContext _context;

    public BlogCategoryRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion

    #region General

    private async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddNewBlogCategoryAsync(BlogCategoryEntity blogCategory)
    {

        await _context.BlogCategory.AddAsync(blogCategory);

        await SaveChangesAsync();
    }

    public async Task<BlogCategoryEntity> GetBlogCategoryByIdAsync(Guid id)
    {
        return await _context.BlogCategory.FindAsync(id);
    }

    public async Task<List<BlogCategoryEntity>> GetListOfBlogCategoriesAsync()
    {
        return await _context.BlogCategory.ToListAsync();
    }


    public async Task UpdateBlogCategoryAsync(BlogCategoryEntity blogCategory) 
    {
         _context.BlogCategory.Update(blogCategory);
        await SaveChangesAsync();

    }

    public async Task DeleteBlogCategoryAsync(Guid id) 
    {
        await _context.BlogCategory.Where(bc=> bc.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    #endregion

}
