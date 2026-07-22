using Core.Models;

namespace MlDAL.Interfaces
{
    public interface IAnalysisRepository
        : IBaseRepository<Analysis>,
          IUpdate<Analysis>,
          IGetAll<Analysis>
    {
        /// <summary>
        /// Retrieves an analysis by its ID, including all packages that contain it.
        /// </summary>
        /// <param name="id">The ID of the analysis.</param>
        /// <returns>
        /// The analysis with its related packages if found; otherwise, <c>null</c>.
        /// </returns>
        public Task<Analysis?> GetByIdWithPackagesAsync(int id);

        /// <summary>
        /// Retrieves multiple analyses by their IDs, including all packages that contain each analysis.
        /// </summary>
        /// <param name="analysisIds">The collection of analysis IDs to retrieve.</param>
        /// <returns>
        /// A collection of analyses with their related packages. Returns an empty collection if no matching analyses are found.
        /// </returns>
        public Task<ICollection<Analysis>> GetByIdWithPackagesAsync(ICollection<int> analysisIds);

        /// <summary>
        /// Retrieves all packages that contain the specified analysis.
        /// </summary>
        /// <param name="analysisId">The ID of the analysis.</param>
        /// <returns>
        /// A list of packages containing the specified analysis.
        /// </returns>
        public Task<ICollection<Containing>?> GetContainingPackagesAsync(int analysisId);

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
