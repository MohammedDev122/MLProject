using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IPackagesRepo : 
        IBaseRepository<Package>,
        IUpdate<Package>,
        IGetAll<Package>
    {

        /// <summary>
        /// Retrieves a package by its identifier together with all related analyses.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <returns>
        /// The package with its containing analyses if found; otherwise, <c>null</c>.
        /// </returns>
        public Task<Package?> GetByIdWithAnalysesAsync(int id);

        /// <summary>
        /// Retrieves all analyses associated with the specified package.
        /// </summary>
        /// <param name="id">The identifier of the package.</param>
        /// <returns>
        /// A list of analyses belonging to the specified package.
        /// Returns an empty list if the package has no associated analyses.
        /// </returns>
        public Task<ICollection<Analysis>?> GetPackageAnalyses (int id);

        /// <summary>
        /// Retrieves a collection of candidate packages that contain at least one of the
        /// specified analyses. Each returned package includes the IDs of all analyses it contains,
        /// which are used later to calculate the matching score.
        /// </summary>
        /// <param name="requiredAnalysesIds">
        /// The IDs of the analyses requested by the patient.
        /// </param>
        /// <param name="requiredPackagesNum">
        /// The maximum number of packages to retrieve.
        /// </param>
        /// <returns>
        /// A collection of <see cref="PackageScore"/> objects containing package information
        /// and the IDs of the analyses included in each package.
        /// </returns>
        public Task<ICollection<PackageScore>> GetMatchingPackages(ICollection<int> requiredAnalysesIds, int requiredPackagesNum, bool LowestCost);


        public Task<Dictionary<int, double>> GetAllPackagesCostAsync();

    }
}
