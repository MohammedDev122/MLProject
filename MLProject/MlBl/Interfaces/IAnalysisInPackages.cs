using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Interfaces
{
    public interface IAnalysisInPackages
    {


        public Task<Dictionary<int, List<int>>> Analysis_Package();

        public Task<Dictionary<int, List<int>>> Packages_Analysis();

        public Task<Dictionary<int, double>> PackagesCost();
        



    }
}
