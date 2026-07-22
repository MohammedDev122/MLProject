using MlBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
namespace MlBL.Interfaces
{
    public interface IRecomendedPackages
    {

        /// <summary>
        /// Finds and ranks the packages that best match the requested analyses.
        ///
        /// Each package receives one point for every requested analysis it contains.
        /// The resulting list is ordered by:
        /// <list type="number">
        /// <item>
        /// <description>Matching score in descending order (highest score first).</description>
        /// </item>
        /// <item>
        /// <description>Package cost in ascending order (lowest cost first) when scores are equal.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="analysesIds">
        /// The IDs of the analyses requested by the patient.
        /// </param>
        /// <returns>
        /// A list of matching packages ordered from the best recommendation
        /// to the least suitable recommendation.
        /// </returns>
        public Task<List<PackageScoreAndPrice>> GetBestMatchingPackages(List<int> analysisIds);


    }
}
