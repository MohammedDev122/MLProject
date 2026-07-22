using Core.Models;
using Microsoft.EntityFrameworkCore;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Repositories
{
    public class CityRepo : ICityRepo
    {  
        private readonly AppDbContext _context;

        public CityRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await _context.Cities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Region>?> GetAllRegions(int cityId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cityId);

            City? city = await _context.Cities
                .AsNoTracking()
                .Include(c => c.Regions)
                .FirstOrDefaultAsync(c => c.Id == cityId);

            if (city == null) 
                return null;

            return city.Regions;

        }
        public async Task<int> AddAsync(City city)
        {
            ArgumentNullException.ThrowIfNull(city);

            _context.Cities.Add(city);

            await _context.SaveChangesAsync();

            return city.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            var city = await GetByIdAsync(id);

            if (city == null)
                return false;

            _context.Cities.Remove(city);

            return await _context.SaveChangesAsync() > 0;
            

        }


        public async Task<bool> UpdateAsync(City updatedCity)
        {
            ArgumentNullException.ThrowIfNull(updatedCity);

            var city = await GetByIdAsync(updatedCity.Id);

            if (city == null) 
                return false;

            city.Name = updatedCity.Name;

            return await _context.SaveChangesAsync() > 0;

        }

    }
}
