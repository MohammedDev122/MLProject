using MlBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.ClassToBeModified
{
    public class PackagesRecommended
    {
        IAnalysisInPackages _IAnalysisInPackages;
        public PackagesRecommended(IAnalysisInPackages AnalysisInPackages)
        {

            _IAnalysisInPackages= AnalysisInPackages;

        }
        public class PackageScoreAndPrice
        {
            public int PackageScore = 0;
            public double PackagePrice = 0;
            public List<int> RemainAnalysis = new List<int>();
        }
        public  async Task<Dictionary<int, PackageScoreAndPrice>> GetBestMatchingPackages(List<int> analysisIds, int TakeOnlyNum, bool LowestCost)
        {
            // AnalysisID -> List<PackageID>
            Dictionary<int, List<int>> data = await _IAnalysisInPackages.Analysis_Package();

            Dictionary<int, PackageScoreAndPrice> packageScore = new Dictionary<int, PackageScoreAndPrice>();

            foreach (int analysisId in analysisIds)
            {
                if (data.ContainsKey(analysisId))
                {
                    foreach (int packageId in data[analysisId])
                    {
                        if (!packageScore.ContainsKey(packageId))
                        {
                            packageScore[packageId] = new PackageScoreAndPrice();
                            packageScore[packageId].PackageScore = 0;
                            packageScore[packageId].PackagePrice =(await _IAnalysisInPackages.PackagesCost())[packageId];


                        }
                        packageScore[packageId].PackageScore++;
                    }


                }

            }
            foreach (var package in packageScore)
            {

                foreach (int analysisId in analysisIds)
                {
                    if (!(await _IAnalysisInPackages.Packages_Analysis())[package.Key].Contains(analysisId))
                    {
                        package.Value.RemainAnalysis.Add(analysisId);
                    }
                }
            }
            Dictionary<int, PackageScoreAndPrice> bestPackages = new Dictionary<int, PackageScoreAndPrice>();
            if (LowestCost)
            {
                foreach (var item in packageScore
                                     .OrderByDescending(x => x.Value.PackageScore).ThenBy(x => x.Value.PackagePrice).Take(TakeOnlyNum))
                {
                    bestPackages.Add(item.Key, item.Value);
                }
            }
            else
            {
                foreach (var item in packageScore
                                                   .OrderByDescending(x => x.Value.PackageScore).ThenByDescending(x => x.Value.PackagePrice).Take(TakeOnlyNum))
                {
                    bestPackages.Add(item.Key, item.Value);
                }

            }
            return bestPackages;
        }
    }
}

