using Core.Models;
using MlBL.Interfaces;
using MlDAL.Interfaces;

namespace MlBL.Services
{
    public class RecommendedPackages : IRecomendedPackages
    {
        private readonly IAnalysisRepository _analysisRepo;

        private readonly IPackagesRepo _packagesRepo;

        public RecommendedPackages (IAnalysisRepository analysisRepo, IPackagesRepo packagesRepo)
        {
            _analysisRepo = analysisRepo;
            _packagesRepo = packagesRepo;
        }

        public async Task<ICollection<PackageScore>> GetMatchingPackagesScore (HashSet<int> analysesIds, int requiredPackagsNum)
        {
            var matchingPackages = await _packagesRepo.GetMatchingPackages(analysesIds, requiredPackagsNum);

            return matchingPackages
                .Select(p => new PackageScore(p)
                {
                    containedAnalysisIds = p.containingAnalyses
                        .Select(c => c.AnalysisID)
                        .ToHashSet()
                })
                .ToList();

        }

        public async Task<ICollection<PackageScore>> GetBestMatchingPackages(HashSet<int> analysesIds, int requiredPackagsNum, bool LowestCostFirst)
        {
            ArgumentNullException.ThrowIfNull(analysesIds);

            // Load candidate packages that contain at least one requested analysis.
            ICollection<PackageScore> packages
                = await GetMatchingPackagesScore(analysesIds, requiredPackagsNum);

            foreach (var package in packages) 
            {
                // Create a copy of the requested analyses.
                package.missedAnalysesIds = new HashSet<int>(analysesIds);

                // Remove analyses already included in the package,
                // leaving only the missing analyses.
                package.missedAnalysesIds.ExceptWith(package.containedAnalysisIds);

                // Calculate the package matching score.
                package.matchingScore = analysesIds.Count() - package.missedAnalysesIds.Count();

                // Load detailed information for the missing analyses.
                // TODO:
                // This currently loads missing analyses with one query per package.
                // Kept intentionally for readability since the maximum expected number
                // of packages is small. Optimize only if profiling shows
                // this becomes a performance bottleneck.
                package.missedAnalyses
                    = await _analysisRepo.GetByIdAsync(package.missedAnalysesIds);
            }
            // Rank packages by matching score and cost preference.
            List<PackageScore> result = new List<PackageScore>();

            if (LowestCostFirst)
            {
                 result = packages
                    .OrderByDescending(p => p.matchingScore)
                        .ThenBy(p => p.PackageCost)
                    .ToList();

                return result;
            }

            result = packages.OrderByDescending(p => p.matchingScore)
                        .ThenByDescending(p => p.PackageCost)
                    .ToList();


            return result;

        }

    }
}
