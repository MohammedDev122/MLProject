using Core.Models;
using FluentValidation;
using MlBL.Validators.AnalysisValidator;
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
        public int? Id { get; set; }

        public string AnalysisName { get; set; }

        public decimal AnalysisCost { get; set; }


        public AnalysisDto(int AnalysisID, string AnalysisName, decimal AnalysisCost)
        {
            this.Id = AnalysisID;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }

        public AnalysisDto(string AnalysisName, decimal AnalysisCost)
        {
            this.Id = null;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
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

   

    }
   
    public class UpdateAnalysisDto
    {
        public int Id { get; set; }
        public decimal AnalysisCost { get; set; }


        public UpdateAnalysisDto(int AnalysisID, decimal AnalysisCost)
        {
            this.Id = AnalysisID;
            this.AnalysisCost = AnalysisCost;
        }

        
    }
}
