using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IContainingRepo:IRepository<Containing>
    {
        public Task<bool> DeleteAllPackage_SContains(int PackageID);
        public Task<bool> DeleteAllAnalysis_SContains(int AnalysisID);

        public Task<Dictionary<int, List<int>>> GetAllAnalysis_Packages();

        public Task<Dictionary<int, List<int>>> GetAllPackagesAnalysis();
        public Task<Dictionary<int, List<string>>> GetAllPackage_SContain(int PackageID);
        public Task<double> GetAllPackage_SContainCost(int PackageID);
        public Task<Dictionary<int, List<string>>> GetAllAnalysis_SContainiers(int AnalysisID);
        public Task<Dictionary<int, List<string>>> GetAll();

        public Task<bool> ISExist(int AnalysisID,int PackageID);

    }
}
