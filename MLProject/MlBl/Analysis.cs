using MlDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBl
{
    public class Analysis
    {
        public int AnalysisID { get; protected set; }
        public string AnalysisName { get; set; }
        public double Cost { get; set; }

        /// <summary>
        /// Indicates why saving the Person Info failed.
        /// </summary>
        public FailCauses.enFailCauses Cause { get; protected set; }
        public enum enMode { enUpdate, enAddNew };

        public AnalysisDto ADTO
        {
            get { return (new AnalysisDto(this.AnalysisID, this.AnalysisName, this.Cost)); }
        }
        public enMode Mode = enMode.enAddNew;

    public static bool DeleteAnalysis(int analysisID)
        {
            return AnalysisData.DeleteAnalysis(analysisID);
        }

        public Analysis(AnalysisDto ADTO,enMode Mode=enMode.enAddNew)
        {
            this.AnalysisID = ADTO.AnalysisID;
            this.AnalysisName = ADTO.AnalysisName;
            this.Cost = ADTO.AnalysisCost;
           this.Mode = Mode;

        }
        public static Analysis FindByID(int AnalysisID)
        {

            AnalysisDto ADTO=AnalysisData.GetAnalysisInfoByID(AnalysisID);
           
            if (ADTO!=null)
            {

                return new Analysis(ADTO,enMode.enUpdate);
            }
            else
                return null;

        }

        public static List<AnalysisDto> GetAll()
        {
            return AnalysisData.GetAllAnalysis();
        }
        public static Dictionary<int, string> GetAllAnalysisMap()
        {
            return AnalysisData.GetAllAnalysisMap();

        }


        bool _CheckIfDataIsCorrect()
        {


            if (Validations.CheckIfNameIsTooShort(AnalysisName))
            {
                Cause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNameContainsOnlySpaces(AnalysisName))
            {
                Cause = FailCauses.enFailCauses.enAnalysisNameIsTooShort;
                return false;
            }
            if (Validations.CheckIfNumIsNull(Cost))
            {
                Cause = FailCauses.enFailCauses.enCostIsNull;
                return false;

            }
            if (Validations.CheckIfNumIsNegative(Cost))
            {
                Cause = FailCauses.enFailCauses.enCostIsNegative;
                return false;

            }

            return true;

        }
        bool _AddNew()
        {
            if (_CheckIfDataIsCorrect())
            {

                this.AnalysisID = AnalysisData.AddNewAnalysis(ADTO);

                if (AnalysisID != -1)
                {
                    return true;
                }
                else
                {
                    Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
                }
            }

            return false;

        }
        bool _Update()
        {
            if (_CheckIfDataIsCorrect())
            {

                if (AnalysisData.UpdateAnalsisInfo(ADTO))
                {
                    return true;
                }

                Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);

            }
            return false;
        }

        public bool SaveAnalysis()
        {

            switch (Mode)
            {
                case (enMode.enAddNew):
                    if (_AddNew())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_Update())
                        return true;
                    else
                        return false;
            }

            return false;
        }
        public static bool Exist(int AnalysisID)
        {
            return AnalysisData.ISExist(AnalysisID);
        }

    }
}
