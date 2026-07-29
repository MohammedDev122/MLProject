using Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Repositories
{
    public class PackageRepo : IPackagesRepo
    {

        private readonly AppDbContext _context;

        public PackageRepo (AppDbContext context)
        {
            _context = context;
        }
      
        public async Task<List<Package>> GetAllAsync()
         {
            return await _context.Packages
                                .Select(p => new Package
                                (
                                    p.PackageID, p.PackageName, p.PackagePhotoPath, p.PackageType,
                                    p.PackageGender, p.packageStatus, p.VisitType, p.PackageCost
                                ))
                                .AsNoTracking()
                                .ToListAsync();
         }

        public async Task<Dictionary<int, double>> GetAllPackagesCostAsync()
        {
            
            return await _context.Packages
                                    .AsNoTracking()
                                    .ToDictionaryAsync(
                                    p => p.PackageID,
                                    p => p.PackageCost);

        }  
            
        public async Task<int> AddAsync(Package newPackage)
        {

            ArgumentNullException.ThrowIfNull(newPackage);

            _context.Packages.Add(newPackage);

            await _context.SaveChangesAsync();  

            return newPackage.PackageID;   

        }

         public async Task <bool> UpdateAsync(Package updatedPackage)
         {
           
            ArgumentNullException.ThrowIfNull(updatedPackage);

            var package = await _context.Packages
                .FirstOrDefaultAsync(p => p.PackageID == updatedPackage.PackageID);

            if (package == null) 
                return false;

            package.PackageCost = updatedPackage.PackageCost;
            package.PackageName = updatedPackage.PackageName;
            package.PackageType = updatedPackage.PackageType;
            package.PackagePhotoPath = updatedPackage.PackagePhotoPath;
            package.PackageGender = updatedPackage.PackageGender;
            package.VisitType = updatedPackage.VisitType;   
            package.packageStatus = updatedPackage.packageStatus;

            await _context.SaveChangesAsync();
            
            return true;

         }

        public async Task<Package?> GetByIdAsync(int packageID)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(packageID);

            return await _context.Packages
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PackageID == packageID);
            
        }

         public async Task<bool> DeleteAsync(int PackageID)
         {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(PackageID);
            
            var package = await GetByIdAsync(PackageID);

            if (package == null) 
                return false;

            _context.Packages.Remove(package);

            return await _context.SaveChangesAsync() > 0;  // means return true if there are any rows affected

         }
 
        
        public async Task<Package?> GetByIdWithAnalysesAsync(int packageID)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(packageID);

            return await _context.Packages
                .AsNoTracking()
                .Include(p => p.containingAnalyses) // this fill only the Analysis Ids not the object cuz that what containings table has
                    .ThenInclude(c => c.analysis) // this fill tha analysis object also
                .FirstOrDefaultAsync(p => p.PackageID == packageID);
        }

        public async Task<ICollection<Analysis>?> GetPackageAnalyses (int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await _context.Packages
                .Where(p => p.PackageID == id)
                .SelectMany(p => p.containingAnalyses
                    .Select(c => c.analysis))
                .AsNoTracking()
                .ToListAsync();

        }

        
        public async Task<ICollection<Package>> GetMatchingPackages (ICollection<int> requiredAnalysesIds, int requiredPackagesNum)
        {
            return await _context.Packages
                .Where(p =>
                    p.containingAnalyses
                    .Any(c => requiredAnalysesIds.Contains(c.AnalysisID)))
                .OrderByDescending(p => p.containingAnalyses.Count())
                .Take(requiredPackagesNum)
                .ToListAsync();

        }


    }
}
