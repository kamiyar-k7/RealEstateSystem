

using Domain.Entities.Location;
using Domain.IRepository;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProvinceRepository : IProvinceRepository
{

    #region Ctor
    private readonly RealEstateDataBaseContext _context;

    public ProvinceRepository(RealEstateDataBaseContext context)
    {
        _context = context;
    }
    #endregion


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ProvinceEntity> GetProvinceById(Guid id)
    {
        return await _context.Province
            .Include(x => x.Cities)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<List<ProvinceEntity>> GetListOfProvinces()
    {
        return await _context.Province.ToListAsync();
    }

    public async Task AddNewProvince(ProvinceEntity Province)
    {

        await _context.Province.AddAsync(Province);
        await SaveChangesAsync();
    }

    public async Task UpdateProvince(ProvinceEntity Province)
    {
        _context.Province.Update(Province);
        await SaveChangesAsync();
    }

    public async Task DeleteProvince(ProvinceEntity Province)
    {
        _context.Attach(Province);
        _context.Remove(Province);
        await SaveChangesAsync();
    }





}
