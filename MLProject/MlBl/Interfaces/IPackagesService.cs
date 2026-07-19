using Core.Models;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Interfaces
{
    public interface IPackagesService
    {

        Task <PackageDTO>? FindByID(int PackageID);


        Task <List<PackageDTO>> GetAll();

       Task<PackageDTO> AddNew(CreatePackageDTO CPDTO);

       Task<bool> Update(UpdatedPackageDto UPDTO);
       Task<bool> Delete(int PackageID);
       Task<bool> Exist(int PackageID);
        Task<Dictionary<int, double>> GetAllPackagesCostAsync();

    }
}
