using Core.Models;
using MlBL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MlBL.Interfaces
{
    public interface IRecomendedPackages
    {
        /// <summary>
        /// Finds and ranks the packages that best match the specified analyses.
        /// </summary>
        /// <param name="analysesIds">
        /// The IDs of the analyses requested by the patient.
        /// </param>
        /// <param name="requiredPackagsNum">
        /// The maximum number of matching packages to retrieve.
        /// </param>
        /// <param name="LowestCostFirst">
        /// Determines how packages with the same matching score are ordered.
        /// If <c>true</c>, lower-cost packages are ranked first; otherwise,
        /// higher-cost packages are ranked first.
        /// </param>
        /// <returns>
        /// A ranked collection of packages, including their matching score,
        /// missing analyses, and package information.
        /// </returns>
        public Task<ICollection<PackageScore>> GetBestMatchingPackages(HashSet<int> analysesIds, int requiredPackagsNum, bool LowestCostFirst)
;


    }
}
