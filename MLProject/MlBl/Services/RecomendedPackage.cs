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


        public async Task<ICollection<PackageScore>> GetBestMatchingPackages(HashSet<int> analysesIds, int requiredPackagsNum, bool LowestCostFirst)
        {
            ArgumentNullException.ThrowIfNull(analysesIds);

            // Load candidate packages that contain at least one requested analysis.
            ICollection<PackageScore> packages
                = await _packagesRepo.GetMatchingPackages(analysesIds, requiredPackagsNum, LowestCostFirst);

            foreach (var package in packages) 
            {
                // Create a copy of the requested analyses.
                package.missedAnalysesIds = new HashSet<int>();

                // Remove analyses already included in the package,
                // leaving only the missing analyses.
                package.missedAnalysesIds = analysesIds.Except(package.containedAnalysisIds).ToHashSet();

                // Load detailed information for the missing analyses.
                // TODO:
                // This currently loads missing analyses with one query per package.
                // Kept intentionally for readability since the maximum expected number
                // of packages is small. Optimize only if profiling shows
                // this becomes a performance bottleneck.
                package.missedAnalyses
                    = await _analysisRepo.GetByIdAsync(package.missedAnalysesIds);
            }


            return packages;

        }

    }
}
