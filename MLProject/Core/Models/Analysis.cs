using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{

    /// <summary>
    /// Represents an analysis entity in the system.
    /// This is the domain model that maps to the Analysis table in the database
    /// and is used throughout the business and data access layers.
    /// </summary>
    public class Analysis
    {
        // can be 0 if it in adding state and Id didn't created yet
        public int AnalysisId { get; set; }
        public string AnalysisName { get; set; }
        public decimal Cost { get; set; }

        public Analysis () { }

        public Analysis (int analysisId, string analysisName, decimal cost)
        {
            AnalysisId = analysisId;
            AnalysisName = analysisName;
            Cost = cost;
        }
        public Analysis(int analysisId, decimal cost)
        {
            AnalysisId = analysisId;
            Cost = cost;
        }

    }
}
