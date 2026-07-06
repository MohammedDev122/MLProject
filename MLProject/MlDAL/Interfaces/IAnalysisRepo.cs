using MlDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IAnalysisRepository
    {
        int AddAnalysis(AnalysisDto newAnalysis);

        bool UpdateAnalysis(AnalysisDto updatedAnalysis);

        /// <summary>
        /// Deletes the analysis with the specified ID from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="analysisID">The ID of the analysis to delete.</param>
        /// <returns>
        /// True if the analysis was deleted successfully; otherwise, false.
        /// </returns>
        bool DeleteAnalysis(int analysisID);

        /// <summary>
        /// Retrieves the analysis with the specified ID from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="analysisID">The ID of the analysis to retrieve.</param>
        /// <returns>
        /// The analysis if found; otherwise, null.
        /// </returns>
        AnalysisDto? GetAnalysisById(int analysisID);

        /// <summary>
        /// Retrieves the analysis with the its name from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="analysisName">The name of the analysis to retrieve.</param>
        /// <returns>
        /// The analysis if found; otherwise, null.
        /// </returns>
        AnalysisDto? GetAnalysisByName(string analysisNane);

        /// <summary>
        /// Retrieves all analysis records from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <returns>
        /// A list containing all analyses.
        /// </returns>
        List<AnalysisDto> GetAllAnalyses();

        /// <summary>
        /// Retrieves all analyses as a dictionary where the key is the analysis ID
        /// and the value is the analysis name.
        /// </summary>
        /// <param name="context">The database context.</param>
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
