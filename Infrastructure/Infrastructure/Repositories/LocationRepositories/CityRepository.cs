
using Domain.Entities.Location;
using Domain.IRepository.LocationIRepositories;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.LocationRepositories;

public  class CityRepository : ICityRepository
{

	#region Ctor
	private readonly RealEstateDataBaseContext _context;

    public CityRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }
    #endregion


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<CityEntity> GetCityByIdAsync(Guid id)
    {
        return await _context.City.FindAsync(id);
    }
    public async Task<List<CityEntity>> GetListOfCitiesAsync(string search , int pageNumber , int pageSize)
    {
        var query = _context.City.AsQueryable();

        if (String.IsNullOrEmpty(search)) 
        {
            query = query.Where(b => b.Name.Contains(search));
        }

        return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

    }

    public async Task AddNewCityAsync(CityEntity city)
    {

        await _context.City.AddAsync(city);
      await  SaveChangesAsync();
    }

    public async Task UpdateCityAsync(CityEntity city)
    {
        _context.City.Update(city);
        await SaveChangesAsync();
    }

    public async Task DeleteCityAsync(CityEntity city)
    {
        _context.Attach(city); 
        _context.Remove(city); 
        await SaveChangesAsync();
    }

   
 
 

}
