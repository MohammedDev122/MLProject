using MlDAL.ClassesToBeModified;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.ClassToBeModified
{
    public class clsRegions


    {
        public int RegionID
        {
            get;
            private set;
        }
        public string RegionName { get; set; }
        public int CityID { get; set; }

        enum enMode { enAddNew, enUpdate }

        enMode Mode = enMode.enAddNew;
        public clsRegions()
        {
            this.RegionID = -1;
            this.RegionName = "";
            this.CityID = -1;
            Mode = enMode.enAddNew;

        }

        private clsRegions(int RegionID, int CityID, string RegionName)
        {
            this.RegionID = RegionID;
            this.RegionName = RegionName;
            this.CityID = CityID;

            Mode = enMode.enUpdate;

        }

        static public clsRegions FindRegionByID(int RegionID)
        {
            string RegionName = "";
            int CityID = -1;
            if (clsRegionsDAL.GetRegionInfo(RegionID, ref RegionName, ref CityID))
            {
                return new clsRegions(RegionID, CityID, RegionName);
            }

            return null;



        }
        static public clsRegions FindRegionByName(string RegionName)
        {
            int RegionID = -1;
            int CityID = -1;
            if (clsRegionsDAL.GetRegionInfo(RegionName, ref RegionID, ref CityID))
            {
                return new clsRegions(RegionID, CityID, RegionName);
            }

            return null;



        }

        bool _CheckIfDataIsCorrect()
        {


            if (clsValidations.CheckIfNameIsTooShort(RegionName))
            {
                return false;
            }

            if (clsValidations.CheckIfstringIsNum(RegionName))
            {
                return false;
            }
            if (!clsCity.Exist(CityID))
            {
                return false;
            }
            return true;

        }
        bool _AddNewRegion()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.RegionID = clsRegionsDAL.AddNewRegion(this.RegionName, this.CityID);
            }
            return this.RegionID != -1;



        }
        /// <summary>
        ///  Used To Save The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewRegion())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateRegion())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateRegion()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsRegionsDAL.UpdateRegionInfo(this.RegionID, this.RegionName, this.CityID);
            }
            return false;
        }
        static public DataTable GetAllRegions()
        {

            return clsRegionsDAL.GetAllRegions();
        }
        static public DataTable GetAllRegionsForCity(int CityID)
        {

            return clsRegionsDAL.GetAllRegionsForCity(CityID);
        }
        static public bool Exist(int RegionID)
        {
            return clsRegionsDAL.ISExist(RegionID);
        }

    }

}
