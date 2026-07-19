using MlBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
namespace MlBL.Interfaces
{
    public interface IPackageRecomended
    {

       
        public  Task<Dictionary<int, PackageScoreAndPrice>> GetBestMatchingPackages(List<int> analysisIds, int TakeOnlyNum, bool LowestCost);









    }
}
