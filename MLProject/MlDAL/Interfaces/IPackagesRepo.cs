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
        public Task<ICollection<Containing>?> GetPackageAnalyses (int id);

        public  Task<Dictionary<int, double>> GetAllPackagesCostAsync();

    }
}
