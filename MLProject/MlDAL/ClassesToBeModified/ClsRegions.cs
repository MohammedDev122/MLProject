using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.ClassesToBeModified
{
    public static class clsRegionsDAL
    {

        //  Regions

        static public bool GetRegionInfo(string RegionName, ref int RegionID, ref int CityID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
           RegionID,
           CityID
      FROM Regions
      where RegionName=@RegionName";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionName", RegionName);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    RegionID = Convert.ToInt32(Reader["RegionID"]);

                    CityID = Convert.ToInt32(Reader["CityID"]);
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }

        static public bool GetRegionInfo(int RegionID, ref string RegionName, ref int CityID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
           RegionName,
           CityID
      FROM Regions
      where RegionID=@RegionID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionID", RegionID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    RegionName = Convert.ToString(Reader["RegionName"]);

                    CityID = Convert.ToInt32(Reader["CityID"]);
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewRegion(string RegionName, int CityID)
        {
            int RegionID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    INSERT INTO Regions
               (RegionName
               ,CityID)
         VALUES
               (@RegionName
               ,@CityID)
		       select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionName", RegionName);


            command.Parameters.AddWithValue("@CityID", CityID);


            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    RegionID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return RegionID;




        }



        static public bool UpdateRegionInfo(int RegionID, string RegionName, int CityID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Regions
       SET RegionName = @RegionName
          ,CityID = @CityID
         WHERE RegionID=@RegionID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionName", RegionName);
            command.Parameters.AddWithValue("@CityID", CityID);

            command.Parameters.AddWithValue("@RegionID", RegionID);



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


        static public bool DeleteRegion(int RegionID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Regions
     WHERE RegionID=@RegionID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionID", RegionID);


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


        static public DataTable GetAllRegions()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtRegions = new DataTable();
            string Query = @"SELECT        Regions.RegionID, Regions.RegionName, Cities.City
FROM            Regions INNER JOIN
                         Cities ON Regions.CityID = Cities.CityID
    ";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtRegions.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRegions;




        }
        static public DataTable GetAllRegionsForCity(int CityID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtRegions = new DataTable();
            string Query = @"SELECT        Regions.RegionID, Regions.RegionName, Cities.City
FROM            Regions INNER JOIN
                         Cities ON Regions.CityID = Cities.CityID
where Cities.CityID=@CityID
    ";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CityID", CityID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtRegions.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRegions;




        }





        static public bool ISExist(int RegionID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
         Found=1 from Regions
      where RegionID=@RegionID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RegionID", RegionID);
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
