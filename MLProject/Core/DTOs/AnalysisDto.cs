using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used to exchange analysis data
    /// between the API and the Business Logic Layer.
    /// </summary>
    public class AnalysisDto
    {
        public int? AnalysisID { get; set; }

        public string AnalysisName { get; set; }

        public decimal AnalysisCost { get; set; }


        public AnalysisDto(int AnalysisID, string AnalysisName, decimal AnalysisCost)
        {
            this.AnalysisID = AnalysisID;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }

        public AnalysisDto(string AnalysisName, decimal AnalysisCost)
        {
            this.AnalysisID = null;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }

        // create an analysis Dot object from analysis domain model

        /// <summary>
        /// create an analysis Dto object from analysis domain model
        /// </summary>
        /// <param name="analysis"></param>
        public AnalysisDto(Analysis analysis) 
        {
            this.AnalysisID = analysis.AnalysisID;
            this.AnalysisName = analysis.AnalysisName;
            this.AnalysisCost = analysis.Cost;
        }

    }

    public class CreateAnalysisDto 
    {

        public string AnalysisName { get; set; }

        public decimal AnalysisCost { get; set; }


        public CreateAnalysisDto(string AnalysisName, decimal AnalysisCost)
        {
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }

        // create an analysis Dot object from analysis domain model

        /// <summary>
        /// create an analysis Dto object from analysis domain model
        /// </summary>
        /// <param name="analysis"></param>
        public CreateAnalysisDto(Analysis analysis)
        {
            this.AnalysisName = analysis.AnalysisName;
            this.AnalysisCost = analysis.Cost;
        }
        public AnalysisDto ToDto()
        {
            return new AnalysisDto(AnalysisName, AnalysisCost);
        }
    }
   
    public class UpdateAnalysisDto
    {
        public int AnalysisID { get; set; }
        public decimal AnalysisCost { get; set; }


        public UpdateAnalysisDto(int AnalysisID, decimal AnalysisCost)
        {
            this.AnalysisID = AnalysisID;
            this.AnalysisCost = AnalysisCost;
        }

        
    }
}
