using Core.Models;

namespace MlDAL.Interfaces
{
    public interface IAnalysisRepository : IRepository<Analysis>
    {
        /// <summary>
        /// Retrieves the analysis with the its name from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="analysisName">The name of the analysis to retrieve.</param>
        /// <returns>
        /// The analysis if found; otherwise, null.
        /// </returns>
        public Task<Analysis>? GetByNameAsync(string analysisNane);

        /// <summary>
        /// Retrieves all analyses as a dictionary where the key is the analysis ID
        /// and the value is the analysis name.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <returns>
        /// A dictionary containing analysis IDs as keys and analysis names as values.
        /// </returns>
        public Task<Dictionary<int, string>> GetMapAsync();

    }
}
