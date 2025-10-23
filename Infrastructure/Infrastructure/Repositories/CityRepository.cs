
using Domain.Entities.Location;
using Domain.IRepository;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

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

    public async Task<CityEntity> GetCityById(Guid id)
    {
        return await _context.City.FindAsync(id);
    }
    public async Task<List<CityEntity>> GetListOfCities()
    {
        return await _context.City.ToListAsync();
    }

    public async Task AddNewCity(CityEntity city)
    {

        await _context.City.AddAsync(city);
      await  SaveChangesAsync();
    }

    public async Task UpdateCity(CityEntity city)
    {
        _context.City.Update(city);
        await SaveChangesAsync();
    }

    public async Task DeleteCity(CityEntity city)
    {
        _context.Attach(city); 
        _context.Remove(city); 
        await SaveChangesAsync();
    }

   
 
 

}
