using MlBl;
using MlDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MlBL.Services.AnalysisService;

namespace MlBL.Entities
{
    public class Analysis
    {
        public int AnalysisID { get; set; }
        public string AnalysisName { get; set; }
        public double Cost { get; set; }

        // to determine the cause of failing
        public FailCauses.enFailCauses failCause { get; set; }

        public enum enMode { enUpdate, enAddNew };

        public enMode Mode = enMode.enAddNew;

        public bool isAdded = false;
        public bool isUpdated = false;

        public Analysis(int analysisID, string analysisName, double cost)
        {
            AnalysisID = analysisID;
            AnalysisName = analysisName;
            Cost = cost;
        }

        public AnalysisDto ADTO
        {
            get { return (new AnalysisDto(this.AnalysisID, this.AnalysisName, this.Cost)); }
        }


        public bool CheckIfDataIsCorrect()
        {


            if (Validations.CheckIfNameIsTooShort(AnalysisName))
            {
                failCause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNameContainsOnlySpaces(AnalysisName))
            {
                failCause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNumIsNull(Cost))
            {
                failCause = FailCauses.enFailCauses.enCostIsNull;
                return false;

            }
            if (Validations.CheckIfNumIsNegative(Cost))
            {
                failCause = FailCauses.enFailCauses.enCostIsNegative;
                return false;

            }

            return true;
        }


        public bool SaveAnalysis()
        {

            switch (Mode)
            {
                case (enMode.enAddNew):
                    if (isAdded)
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (isUpdated)
                        return true;
                    else
                        return false;
            }

            return false;
        }
    }
}
