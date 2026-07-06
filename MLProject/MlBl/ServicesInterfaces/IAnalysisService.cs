using MlBL.Entities;
using MlDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.ServicesInterfaces
{
    public interface IAnalysisService
    {
        /// <summary>
        /// Validates the analysis data and add the new analysis in the database.
        /// </summary>
        /// <param name="newAnalysis">
        /// The analysis data containing the added values.
        /// </param>
        /// <returns>
        /// Analysis Id if the analysis was added successfully; otherwise, -1.
        /// </returns>
        int AddAnalysis(Analysis newAnalysis);


        /// <summary>
        /// Validates the analysis data and updates the corresponding analysis in the database.
        /// </summary>
        /// <param name="updatedAnalysis">
        /// The analysis data containing the updated values.
        /// </param>
        /// <returns>
        /// True if the analysis was updated successfully; otherwise, false.
        /// </returns>
        bool UpdateAnalysis(Analysis updatedAnalysis);

        /// <summary>
        /// Deletes the analysis with the specified ID.
        /// </summary>
        /// <param name="analysisId">
        /// The ID of the analysis to delete.
        /// </param>
        /// <returns>
        /// True if the analysis was deleted successfully; otherwise, false.
        /// </returns>
        bool DeleteAnalysis(int analysisId);

        /// <summary>
        /// Retrieves the analysis with the specified ID.
        /// </summary>
        /// <param name="analysisId">
        /// The ID of the analysis to retrieve. Must be greater than zero.
        /// </param>
        /// <returns>
        /// The requested analysis if found; otherwise, null.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="analysisId"/> is less than or equal to zero.
        /// </exception>
        AnalysisDto? GetAnalysisById(int analysisId);

        /// <summary>
        /// Retrieves the analysis with the specified name.
        /// </summary>
        /// <param name="analysisName">
        /// The name of the analysis to retrieve. Cannot be null or empty.
        /// </param>
        /// <returns>
        /// The requested analysis if found; otherwise, null.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="analysisName"/> is null or empty.
        /// </exception>

        AnalysisDto? GetAnalysisByName(string analysisNane);

        /// <summary>
        /// Retrieves all analyses.
        /// </summary>
        /// <returns>
        /// A list containing all analyses.
        /// </returns>
        List<AnalysisDto> GetAllAnalyses();

        /// <summary>
        /// Retrieves all analyses.
        /// </summary>
        /// <returns>
        /// A dictionary containing analysis IDs as keys and analysis names as values.
        /// </returns>
        Dictionary<int, string> GetAllAnalysisMap();


        /// <summary>
        /// Determines whether an analysis with the specified ID exists in the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="analysisID">The ID of the analysis to search for.</param>
        /// <returns>
        /// True if an analysis with the specified ID exists; otherwise, false.
        /// </returns
        bool Exists(int analysisID);
    }
}
