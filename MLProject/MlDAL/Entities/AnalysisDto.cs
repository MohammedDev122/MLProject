using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Entities
{
    /// <summary>
    /// The data container of Analysis Entity
    /// </summary>
    public class AnalysisDto
    {
        public AnalysisDto(int AnalysisID, string AnalysisName, double AnalysisCost)
        {
            this.AnalysisID = AnalysisID;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }
        public int AnalysisID { get; set; }

        public string AnalysisName { get; set; }

        public double AnalysisCost { get; set; }



    }
}
