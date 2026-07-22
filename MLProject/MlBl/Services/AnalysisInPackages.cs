using MlBL.Interfaces;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class AnalysisInPackages:IAnalysisInPackages
    {

        IContainingRepo _ContainRepo;
        IPackagesRepo _PackagesRepo;
        
       public  AnalysisInPackages(IContainingRepo ContainRepo,IPackagesRepo packageRepo)
       {
            _ContainRepo = ContainRepo;
            _PackagesRepo= packageRepo;

        }
        public  async Task<Dictionary<int, List<int>>> Analysis_Package()
        {
            return await _ContainRepo.GetAllAnalysis_Packages();
        }
        public  async Task<Dictionary<int, List<int>>> Packages_Analysis()
        {
            return await _ContainRepo.GetAllPackagesAnalysis();
        }
        public  async Task<Dictionary<int, double>> PackagesCost()
        {
            return await _PackagesRepo.GetAllPackagesCostAsync();
        }


    }
}
