
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

    public async Task AddNewBlogCategory(BlogCategoryEntity blogCategory)
    {

        await _context.BlogCategory.AddAsync(blogCategory);

        await SaveChangesAsync();
    }

    public async Task<BlogCategoryEntity> GetBlogCategoryById(Guid id)
    {
        return await _context.BlogCategory.FindAsync(id);
    }

    public async Task<List<BlogCategoryEntity>> GetListOfBlogCategories()
    {
        return await _context.BlogCategory.ToListAsync();
    }


    public async Task UpdateBlogCategory(BlogCategoryEntity blogCategory) 
    {
         _context.BlogCategory.Update(blogCategory);
        await SaveChangesAsync();

    }

    public async Task DeleteBlogCategory(Guid id) 
    {
        await _context.BlogCategory.Where(bc=> bc.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
    }

    #endregion

}
