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
    public class LabRepo : ILabRepo
    {
        private readonly AppDbContext _context;

        public LabRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lab?> GetByIdAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await _context.Laps
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

        }

        public async Task<List<Lab>> GetAllAsync()
        {
            return await _context.Laps
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<int> AddAsync(Lab newLab)
        {
            ArgumentNullException.ThrowIfNull(newLab);

            _context.Laps .Add(newLab);

            await _context.SaveChangesAsync();

            return newLab.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        { 
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            var lab = await GetByIdAsync(id);

            if (lab == null)
                return false;

            _context.Laps.Remove(lab);

            return await _context.SaveChangesAsync() > 0;

        }



        public async Task<bool> UpdateAsync(Lab updatedLab)
        {
            ArgumentNullException.ThrowIfNull(updatedLab);

            _context.Laps.Update(updatedLab);
            
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
