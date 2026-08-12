using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IContainingRepo : IBaseRepository<Containings>
    {

        /// <summary>
        /// Retrieves the ID of the containing record that associates the specified
        /// package with the specified analysis.
        /// </summary>
        /// <param name="packageId">The ID of the package.</param>
        /// <param name="analysisId">The ID of the analysis.</param>
        /// <returns>
        /// The ID of the matching containing record if found; otherwise, returns 0
        /// </returns>
        /// <remarks>
        /// This method is primarily used when removing an analysis from a specific package.
        /// Since the relationship between packages and analyses is stored in the
        /// <c>Containing</c> table, the containing record ID is required to delete
        /// the association.
        /// </remarks>
        public Task<int> GetIdAsync (int packageId, int analysisId);

        /// <summary>
        /// Deletes the association between the specified package and analysis.
        /// </summary>
        /// <param name="packageId">The ID of the package.</param>
        /// <param name="analysisId">The ID of the analysis.</param>
        /// <returns>
        /// indicates whether the deletion was successful.
        /// </returns>
        public Task<bool> DeleteAsync (int packageId, int analysisId);

        /// <summary>
        /// Retrieves all package-analysis associations.
        /// </summary>
        /// <returns>
        /// A dictionary where:
        /// <list type="bullet">
        ///     <item>
        ///         <description>
        ///             The key is the containing record ID.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///             The value is a list containing the package name and the associated analysis name.
        ///         </description>
        ///     </item>
        /// </list>
        /// </returns>
        public Task<Dictionary<int, List<string>>> GetAll();

        /// <summary>
        /// Adds a new analysis to the specified package.
        /// </summary>
        /// <param name="packageId">The ID of the package.</param>
        /// <param name="analysisId">The ID of the analysis to be added.</param>
        /// <returns>
        /// The ID of the newly created association record in the <c>Containing</c> table.
        /// </returns>
        public Task<int> AddAsync (int packageId, int analysisId);

        /*
        public Task<bool> DeleteAllPackage_SContains(int PackageID);
        public Task<bool> DeleteAllAnalysis_SContains(int AnalysisID);

      
        public Task<Dictionary<int, List<int>>> GetAllAnalysis_Packages();

        public Task<Dictionary<int, List<int>>> GetAllPackagesAnalysis();
        public Task<Dictionary<int, List<string>>> GetAllPackage_SContain(int PackageID);
        public Task<double> GetAllPackage_SContainCost(int PackageID);
        public Task<Dictionary<int, List<string>>> GetAllAnalysis_SContainiers(int AnalysisID);


        public Task<bool> ISExist(int AnalysisID,int PackageID);
        */
    }
}
