
using Domain.Entities.Property;
using Domain.IRepository;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{

    #region Ctor

    private readonly RealEstateDataBaseContext _context;

    public PropertyRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region General

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

  

    public async Task<List<PropertyEntity>> GetListOfProperties()
    {
        return await _context.Property
            .Include(p => p.PropertyType)
            .Include(p => p.PropertyImages)
            .ToListAsync();
    }
    public async Task<PropertyEntity> GetPropertyById(Guid id)
    {
        return await _context.Property
            .Include(p => p.PropertyType)
            .Include(p => p.PropertyImages)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    

    public async Task AddNewProperty(PropertyEntity property)
    {

        await _context.Property.AddAsync(property);
        await SaveChangesAsync();

    }

    public async Task UpdateProperty(PropertyEntity property)
    {

        await _context.Property.AddAsync(property);
        await SaveChangesAsync();

    }

    #region Delete Property

    public async Task<PropertyEntity> FindProperty(Guid propertyId)
    {
        return await _context.Property.FindAsync(propertyId);
    }
    public async Task DeleteProperty(PropertyEntity property)
    {

        property.IsDeleted = true;

        await SaveChangesAsync();



    }

    #endregion


    #endregion

    public async Task<List<PropertyEntity>> GetPropertiesByType(Guid propertyTypeId)
    {
        return await _context.Property
            .Include(p => p.PropertyType)
            .Include(p => p.PropertyImages)
            .Where(p => p.PropertyType.Id == propertyTypeId)
            .ToListAsync();
    }



}
