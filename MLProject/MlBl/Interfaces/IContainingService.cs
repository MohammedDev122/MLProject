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
    public interface IContainingService
    {

        public Task<ContainingDTO>? FindByID(int ContainID);

        public Task<List<StringContainingDTO>> GetAll();

        public Task<bool> Delete(int ContainID);

        public Task<List<StringContainingDTO>> GetAllPackageContains(int PackageID);

        public Task<List<StringContainingDTO>> GetAllAnalysisContained(int AnalysisID);

        public Task<double?> GetAllAnalysisInPackageCost(int PackageID);

        public Task<ContainingDTO> AddNew(CreateContainingDTO CCDTO);


        public Task<bool> Exist(int ContainID);

        public Task<bool> Exist(int AnalysisID, int PackageID);
       







    }
}
