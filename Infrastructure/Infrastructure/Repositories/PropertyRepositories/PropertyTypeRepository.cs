

using Domain.Entities.Property;
using Domain.IRepository.PropertyIRepsitories;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PropertyRepositories;

public class PropertyTypeRepository: IPropertyTypeRepository
{

    #region Ctor

    private readonly RealEstateDataBaseContext _context;

    public PropertyTypeRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }

    #endregion


    #region General


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


    public async Task AddNewPropertyType(PropertyTypeEntity typeEntity)
    {

        await _context.PropertyType.AddAsync(typeEntity);
       await SaveChangesAsync();

    }

    public async Task<PropertyTypeEntity> GetPropertyTypeById(Guid id)
    {
        return await _context.PropertyType.FindAsync(id);
    }


    public async Task<List<PropertyTypeEntity>> GetListOFPropertyTypes() 
    {

        return await _context.PropertyType.ToListAsync();

    }

    public async Task UpdateProperty(PropertyTypeEntity propertyTypeEntity)
    {
        _context.PropertyType.Update(propertyTypeEntity);
        await SaveChangesAsync();
    }

    public async Task DeleteProperty(Guid Id) 
    {
        await _context.PropertyType.Where(pt => pt.Id == Id).ExecuteDeleteAsync();
    }



    #endregion

}
