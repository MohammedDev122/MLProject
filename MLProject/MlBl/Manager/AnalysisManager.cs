using Core.Models;
using MlBl;
using MlBL.DTOs;
using MlBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Entities
{
    public class AnalysisManager
    {
        
        public Analysis analysis { get; set; }

        // to determine the cause of failing
        public FailCauses.enFailCauses failCause { get; set; }


        public enum enMode { enUpdate, enAddNew };

        public enMode Mode = enMode.enAddNew;

        public bool isAdded { get; set; }
        public bool isUpdated { get; set; }

        public AnalysisManager (Analysis analysis)
        {
            this.analysis = analysis;
            isAdded = false;
            isUpdated = false;
        }

        public AnalysisManager(AnalysisDto analysisDto)
        {
            this.analysis = new Analysis(analysisDto);
            isAdded = false;
            isUpdated = false;
        }

        public bool CheckIfDataIsCorrect()
        {


            if (Validations.CheckIfNameIsTooShort(analysis.AnalysisName))
            {
                failCause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNameContainsOnlySpaces(analysis.AnalysisName))
            {
                failCause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNumIsNull(analysis.Cost))
            {
                failCause = FailCauses.enFailCauses.enCostIsNull;
                return false;

            }
            if (Validations.CheckIfNumIsNegative(analysis.Cost))
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
