using Core.Models;

namespace MlDAL.Interfaces
{
    public interface IAnalysisRepository
        : IBaseRepository<Analysis>,
          IUpdate<Analysis>,
          IGetAll<Analysis>
    {

        /// <summary>
        /// Retrieves all analyses whose IDs match the specified collection of analysis IDs.
        /// </summary>
        /// <param name="analysisIds">
        /// The collection of analysis IDs to retrieve.
        /// </param>
        /// <returns>
        /// A list of matching analyses if any are found; otherwise, <c>null</c>.
        /// </returns>
        public Task<ICollection<Analysis>?> GetByIdAsync(ICollection<int> analysisIds);

        /// <summary>
        /// Retrieves an analysis by its ID, including all packages that contain it.
        /// </summary>
        /// <param name="id">The ID of the analysis.</param>
        /// <returns>
        /// The analysis with its related packages if found; otherwise, <c>null</c>.
        /// </returns>
        public Task<Analysis?> GetByIdWithPackagesAsync(int id);

      
        /// <summary>
        /// Retrieves all packages that contain the specified analysis.
        /// </summary>
        /// <param name="analysisId">The ID of the analysis.</param>
        /// <returns>
        /// A list of packages containing the specified analysis.
        /// </returns>
        public Task<ICollection<Package>?> GetContainingPackagesAsync(int analysisId);

        /*
        /// <summary>
        /// Retrieves all analyses as a dictionary where the key is the analysis ID
        /// and the value is the analysis name.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <returns>
        /// A dictionary containing analysis IDs as keys and analysis names as values.
        /// </returns>
        public Task<Dictionary<int, string>> GetMapAsync();
        */
    }
}
