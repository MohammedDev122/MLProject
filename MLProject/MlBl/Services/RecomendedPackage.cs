using Core.Models;
using MlBL.Interfaces;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class RecommendedPackages : IRecomendedPackages
    {
        private readonly IAnalysisRepository _analysisRepo;

        public RecommendedPackages (IAnalysisRepository analysisRepo)
        {
            _analysisRepo = analysisRepo;
        }

        public async Task<List<PackageScoreAndPrice>> GetBestMatchingPackages(List<int> analysesIds)
        {
            // Load the requested analyses together with all packages that contain them.
            ICollection<Analysis> detailedAnalyses
                = await _analysisRepo.GetByIdWithPackagesAsync(analysesIds);

            // Stores each matching package only once and tracks its score.
            Dictionary<int, PackageScoreAndPrice> suggestedPackages
                = new Dictionary<int, PackageScoreAndPrice>();

            foreach (Analysis analysis in detailedAnalyses)
            {
                foreach (Containing containing in analysis.containedPackages)
                {
                    PackageScoreAndPrice p = new PackageScoreAndPrice(containing.package);

                    // Package already exists; increase its matching score.
                    if (suggestedPackages.TryGetValue(containing.PackageID, out var existing))
                    {
                        existing.IncreaseScoreByOne();
                    }

                    // First occurrence of this package; add it to the suggestions.
                    else
                    {
                        suggestedPackages.Add(p.packageId, p);
                    }

                }
            }

            // Rank packages by highest matching score, then by lowest package cost.
            var result = suggestedPackages
                    .OrderByDescending(p => p.Value.PackageScore)
                    .ThenBy(p => p.Value.PackageCost)
                    .Select(p => p.Value)
                    .ToList();


            return result;

        }
    }
}
