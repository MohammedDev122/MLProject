using MlDAL.ClassesToBeModified;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.ClassToBeModified
{
    public class clsCity

    {
        public int CityID
        {
            get;
            private set;
        }
        public string CityName { get; set; }

        enum enMode { enAddNew, enUpdate }

        enMode Mode = enMode.enAddNew;
        public clsCity()
        {
            this.CityID = -1;
            this.CityName = "";

            Mode = enMode.enAddNew;

        }

        private clsCity(int CityID, string CityName)
        {
            this.CityID = CityID;
            this.CityName = CityName;


            Mode = enMode.enUpdate;

        }
        static public clsCity FindCityByID(int CityID)
        {
            string CityName = "";
            if (clsCitiesDAL.GetCityInfo(CityID, ref CityName))
            {
                return new clsCity(CityID, CityName);
            }

            return null;



        }
        static public clsCity FindCityByName(string CityName)
        {
            int CityID = -1;
            if (clsCitiesDAL.GetCityInfo(CityName, ref CityID))
            {
                return new clsCity(CityID, CityName);
            }

            return null;



        }

        bool _CheckIfDataIsCorrect()
        {


            if (clsValidations.CheckIfNameIsTooShort(CityName))
            {
                return false;
            }

            if (clsValidations.CheckIfStringContainAnyNums(CityName))
            {
                return false;
            }

            return true;

        }
        bool _AddNewCity()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.CityID = clsCitiesDAL.AddNewCity(this.CityName);
            }
            return this.CityID != -1;



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

                    if (_AddNewCity())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateCity())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateCity()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsCitiesDAL.UpdateCityInfo(this.CityID, this.CityName);
            }
            return false;
        }
        static public DataTable GetAllCities()
        {

            return clsCitiesDAL.GetAllCities();
        }
        static public bool Exist(int CityID)
        {
            return clsCitiesDAL.ISExist(CityID);
        }

    }

}
