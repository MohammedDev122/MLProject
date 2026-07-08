using MlBL.DTOs;
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
        public int AnalysisID { get; set; }
        public string AnalysisName { get; set; }
        public double Cost { get; set; }

        public Analysis (int analysisId, string analysisName, double cost)
        {
            AnalysisID = analysisId;
            AnalysisName = analysisName;
            Cost = cost;
        }

        public Analysis (AnalysisDto analysisDto)
        {
            AnalysisID = analysisDto.AnalysisID;
            AnalysisName = analysisDto.AnalysisName;
            Cost = analysisDto.AnalysisCost;
        }

    }
}
