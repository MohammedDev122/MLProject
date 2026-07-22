using Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MlDAL.Repositories
{

    public class AnalysisRepo : IAnalysisRepository
    {
        private readonly AppDbContext _context;

        public AnalysisRepo(AppDbContext context)
        {
            _context = context;
        }
       
    /*
        public async Task<Dictionary<int, string>> GetMapAsync()
        {
            

            return await _context.Analysis
                                .Select(a => new { a.AnalysisId, a.AnalysisName })
                                .ToDictionaryAsync(a => a.AnalysisId, a => a.AnalysisName);

        }
    */

        public async Task<Analysis?> GetByIdAsync(int analysisID)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisID);

            return await _context.Analysis
                            .AsNoTracking()
                            .FirstOrDefaultAsync(a => a.AnalysisId == analysisID);

        }


        public async Task<int> AddAsync(Analysis newAnalysis)
        {
            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null


            // Mark this entity as Added
            _context.Analysis.Add(newAnalysis);

            // save  on database
            await _context.SaveChangesAsync();

            return newAnalysis.AnalysisId;
        }

        public async Task<bool> UpdateAsync(Analysis updatedAnalysis)
        {

            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            // Load then update method

            // Load the row
            var analysis = await _context.Analysis.
                FirstOrDefaultAsync(a => a.AnalysisId == updatedAnalysis.AnalysisId);

            if (analysis == null)
                return false;

            // update the row
            analysis.Cost = updatedAnalysis.Cost;

            // save changes on database
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Analysis>> GetAllAsync()
        {
            return await _context.Analysis
                                .Select(a => new Analysis
                                (
                                    a.AnalysisId,
                                    a.AnalysisName,
                                    a.Cost
                                ))
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int analysisID)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisID);

            // load then delete approach 
            var analysis =
                await GetByIdAsync(analysisID);

            if (analysis == null)
                return false;   


            _context.Analysis.Remove(analysis);

            return await _context.SaveChangesAsync() > 0; // means return true if there are any rows affected
        }


        public async Task<Analysis?> GetByIdWithPackagesAsync(int analysisID)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisID);

            return await _context.Analysis
                .AsNoTracking()
                .Include(a => a.containedPackages)
                    .ThenInclude(p => p.package)
                .FirstOrDefaultAsync(a => a.AnalysisId == analysisID);

        }

        public async Task<ICollection<Containing>?> GetContainingPackagesAsync(int analysisId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisId);

            var analysis = await GetByIdWithPackagesAsync(analysisId);

            return analysis.containedPackages;

          
        }


        public async Task<ICollection<Analysis>> GetByIdWithPackagesAsync (ICollection<int> analysisIds)
        {
            return await _context.Analysis
                .AsNoTracking()
                .Where(a => analysisIds.Contains(a.AnalysisId))
                .Include(a => a.containedPackages)
                    .ThenInclude(p => p.package)
                .ToListAsync();
        }

    }
}