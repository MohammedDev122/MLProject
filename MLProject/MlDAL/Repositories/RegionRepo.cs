using Core.Models;
using Microsoft.EntityFrameworkCore;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Repositories
{
    public class RegionRepo : IRegionRepo
    {
        private readonly AppDbContext _context;

        public RegionRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Region?> GetByIdAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await _context.Regions
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Lab>?> GetAllLabs(int regionId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(regionId);

            Region? region = await _context.Regions
                .AsNoTracking()
                .Include(r => r.labs)
                .FirstOrDefaultAsync(r => r.Id == regionId);

            if (region == null)
                return null;

            return region.labs;

        }


        public async Task<int> AddAsync(Region newRegion)
        {
            ArgumentNullException.ThrowIfNull(newRegion);

            _context.Regions.Add(newRegion);

            await _context.SaveChangesAsync();

            return newRegion.Id;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            var region = await GetByIdAsync(id);

            if (region == null) 
                return false;

            _context.Regions.Remove(region);

            return await _context.SaveChangesAsync() > 0;

        }



        public async Task<bool> UpdateAsync(Region updatedRegion)
        {
            ArgumentNullException.ThrowIfNull(updatedRegion);

            var region = await GetByIdAsync(updatedRegion.Id);

            if (region == null)
                return false;

            region.Name = updatedRegion.Name;
            region.CityId = updatedRegion.CityId;

            return await _context.SaveChangesAsync() > 0;


        }

    }
}
