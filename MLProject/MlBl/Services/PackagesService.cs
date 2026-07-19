using Core.Models;
using Microsoft.Data.SqlClient;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class PackagesService:IPackagesService
    {
        private readonly IPackagesRepo _packagesRepo;
      public  PackagesService(IPackagesRepo packagesRepo)
        {
            _packagesRepo = packagesRepo;
        }
        public async Task<PackageDTO>? FindByID(int PackageID)
        {
            if (PackageID <= 0) throw new ArgumentOutOfRangeException((nameof(PackageID)), "Package ID must be greater than zero.");
            Packages package=await  _packagesRepo.GetByIdAsync(PackageID);
            return package == null ? null : package.ToPackageDTO();

        }

        public async Task<PackageDTO>AddNew(CreatePackageDTO CPDTO)
        {
            if (CPDTO==null)throw new ArgumentNullException(nameof(CPDTO),"Package Entity Can Not Be Null");
            Packages Package = CPDTO.ToEntity();
         Package.PackageID= await _packagesRepo.AddAsync(Package);
            return Package.PackageID > 0 ? Package.ToPackageDTO() : null;


        }

        public async Task<bool> Update(UpdatedPackageDto UPDTO)
        {
            if (UPDTO == null) throw new ArgumentNullException(nameof(UPDTO), "Package Entity Can Not Be Null");
            Packages Package = UPDTO.ToEntity();
            bool Updated= await _packagesRepo.UpdateAsync(Package);
            return Updated;


        }
        public async Task<bool> Delete(int PackageID)
        {
            if (PackageID <= 0) throw new ArgumentOutOfRangeException(nameof(PackageID), "Package ID must be greater than zero.");
            if (!await Exist(PackageID)) return false;
            bool Deleted = await _packagesRepo.DeleteAsync(Convert.ToInt32(PackageID));
            return Deleted;


        }

        public async Task<List<PackageDTO>> GetAll()
        {

            List<Packages> LPackages = new List<Packages>();
           LPackages=await _packagesRepo.GetAllAsync();
            return  LPackages.Select(x=>x.ToPackageDTO()).ToList();
        }
        public async Task<bool>Exist(int PackageID)
        {

            return await _packagesRepo.ExistsAsync(PackageID);

        }
        public async Task<Dictionary<int, double>> GetAllPackagesCostAsync()
        {
            Dictionary<int, double> AllPCost =await _packagesRepo.GetAllPackagesCostAsync();
            return AllPCost;
        }


    }
}
