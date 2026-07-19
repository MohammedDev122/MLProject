using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.ClassesToBeModified
{
    public static class clsLapDAL

    {
        //  Laps
        static public bool GetLapInfo(int LapID, ref int LapName, ref string LapAddress, ref int LapTypeID, ref int RegionID, ref int LapStatusID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
           LapName,
           LapAddress,
           LapTypeID,
           RegionID,
LapStatusID
      FROM Laps
      where LapID=@LapID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LapID", LapID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    LapName = Convert.ToInt32(Reader["LapName"]);

                    LapAddress = Convert.ToString(Reader["LapAddress"]);
                    LapTypeID = Convert.ToInt32(Reader["LapTypeID"]);
                    RegionID = Convert.ToInt32(Reader["RegionID"]);
                    LapStatusID = Convert.ToInt32(Reader["LapStatusID"]);

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewLap(int DoctorID, int MedicalRecordID, int SpecilizationID, int ServiceID, int LapStatusID)
        {
            int DiagnosisID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    INSERT INTO Diagnoisis
               (DoctorID
               ,MedicalRecordID
               ,SpecilizationID
               ,ServiceID
,LapStatusID)
         VALUES
               (@DoctorID
               ,@MedicalRecordID
               ,@SpecilizationID
               ,@ServiceID
,@LapStatusID)
		       select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            if (MedicalRecordID != -1)
                command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            else
                command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);

            command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);


            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            command.Parameters.AddWithValue("@LapStatusID", LapStatusID);


            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    DiagnosisID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return DiagnosisID;




        }



        static public bool UpdateLapInfo(int LapID, int LapName, string LapAddress, int LapTypeID, int RegionID, int LapStatusID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Laps
       SET
          LapName = @LapName
          ,LapAddress = @LapAddress
          ,LapTypeID = @LapTypeID
          ,RegionID = @RegionID
          ,LapStatusID = @LapStatusID
     WHERE LapID=@LapID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LapID", LapID);
            command.Parameters.AddWithValue("@LapName", LapName);
            command.Parameters.AddWithValue("@LapAddress", LapAddress);

            command.Parameters.AddWithValue("@LapTypeID", LapTypeID);



            command.Parameters.AddWithValue("@RegionID", RegionID);
            command.Parameters.AddWithValue("@LapStatusID", LapStatusID);



            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Updated = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Updated;




        }


        static public bool DeleteLap(int LapID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Laps
     WHERE LapID=@LapID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LapID", LapID);


            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Delete = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Delete;





        }


        static public DataTable GetAllLaps()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtLaps = new DataTable();
            string Query = @"SELECT        Laps.LapID, Laps.LapName, Laps.LapAddress, LapTypes.Type, Regions.RegionName, Cities.City, LapStatus.LapStatus
FROM            Laps INNER JOIN
                         LapTypes ON Laps.LapTypeID = LapTypes.LapTypeID INNER JOIN
                         LapStatus ON Laps.LapStatusID = LapStatus.LapStatusID INNER JOIN
                         Regions ON Laps.RegionID = Regions.RegionID INNER JOIN
                         Cities ON Regions.CityID = Cities.CityID
    ";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtLaps.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtLaps;




        }






        static public bool ISExist(int LapID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
         Found=1 from Laps
      where LapID=@LapID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LapID", LapID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    Exist = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Exist;




        }


























    }

}
