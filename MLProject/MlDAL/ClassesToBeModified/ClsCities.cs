using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.ClassesToBeModified
{
    static public class clsCitiesDAL
    {


        //  Cities
        static public bool GetCityInfo(int CityID, ref string CityName)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
          City
      FROM Cities
      where CityID=@CityID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CityID", CityID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    CityName = Convert.ToString(Reader["City"]);

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public bool GetCityInfo(string CityName, ref int CityID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
          CityID
      FROM Cities
      where City=@City";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@City", CityName);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    CityID = Convert.ToInt32(Reader["CityID"]);

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }

        static public int AddNewCity(string CityName)
        {
            int CityID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    INSERT INTO Cities
               (City)
         VALUES
               (@City)
		       select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@City", CityName);


            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    CityID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return CityID;




        }



        static public bool UpdateCityInfo(int CityID, string CityName)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Cities
       SET 
          City = @City
               WHERE CityID=@CityID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CityID", CityID);
            command.Parameters.AddWithValue("@City", CityName);



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


        static public bool DeleteCity(int CityID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Cities
     WHERE CityID=@CityID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CityID", CityID);


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


        static public DataTable GetAllCities()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtCities = new DataTable();
            string Query = @"SELECT        CityID, City
FROM            Cities
    ";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtCities.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtCities;




        }



        static public bool ISExist(int CityID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
    SELECT 
         Found=1 from Cities
      where CityID=@CityID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CityID", CityID);
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
