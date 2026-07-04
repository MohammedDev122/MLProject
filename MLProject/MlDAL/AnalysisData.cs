using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace MlDAL
{
    public class AnalysisDto
    {
       public AnalysisDto(int AnalysisID, string AnalysisName, double AnalysisCost) {
            this.AnalysisID = AnalysisID;
            this.AnalysisName = AnalysisName;
            this.AnalysisCost = AnalysisCost;
        }
        public int AnalysisID { get; set;}

        public string AnalysisName { get; set; }

        public double AnalysisCost { get; set; }



    }
   
    public class AnalysisData
    {
        //  Analysis
        static public Dictionary<int, string> GetAllAnalysisMap()
        {
          
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);
            Dictionary<int, string> Result = new Dictionary<int, string>();
            string Query = @"SELECT 
      analysisID,
       AnalysisName
    
  FROM Analysis

    ";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        int AnalysisID = (int)Reader["AnalysisID"];
                        string AnalysisName = Convert.ToString(Reader["AnalysisName"]);

                        if (!Result.ContainsKey(AnalysisID))
                        {
                            Result[AnalysisID] = AnalysisName;
                        }

                    }
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return Result;


        }

        static public AnalysisDto GetAnalysisInfoByID(int AnalysisID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);

            string Query = @"
SELECT 
      
       AnalysisName,
       Cost
  FROM Analysis
  where AnalysisID=@AnalysisID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", AnalysisID);
            try
            {

                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {

                    if (Reader.Read())
                    {
                        return new AnalysisDto(
                            AnalysisID,
                            Reader.GetString(Reader.GetOrdinal("AnalysisName")),
                            Reader.GetDouble(Reader.GetOrdinal("Cost"))



                        );


                    }
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return null;




        }
        static public int AddNewAnalysis(AnalysisDto ADTO)
        {
          
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);
            ADTO.AnalysisID = -1;
            string Query = @"
INSERT INTO Analysis
           (AnalysisName
           ,Cost
           )
     VALUES
           (@AnalysisName
           ,@Cost
           )
		   select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisName", ADTO.AnalysisName);


            command.Parameters.AddWithValue("@Cost", ADTO.AnalysisCost);




            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ADTO.AnalysisID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return ADTO.AnalysisID;




        }
        static public bool GetAnalysisInfoByName(string AnalysisName, ref int AnalysisID, ref double Cost)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);

            string Query = @"
SELECT 
      AnalysisID,
       
       Cost
  FROM Analysis
  where AnalysisName=@AnalysisName";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisName", AnalysisName);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    AnalysisID = Convert.ToInt32(Reader["AnalysisID"]);
                    Cost = Convert.ToDouble(Reader["Cost"]);
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }



        static public bool UpdateAnalsisInfo(AnalysisDto ADTO)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);
            string Query = @"UPDATE Analysis
   SET AnalysisName = @AnalysisName
      ,Cost = @Cost
 WHERE AnalysisID=@AnalysisID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", ADTO.AnalysisID);
            command.Parameters.AddWithValue("@AnalysisName", ADTO.AnalysisName);


            command.Parameters.AddWithValue("@Cost", ADTO.AnalysisCost);



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


        static public bool DeleteAnalysis(int AnalysisID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);
            string Query = @"Delete from Analysis
 WHERE AnalysisID=@AnalysisID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", AnalysisID);


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


        static public List<AnalysisDto> GetAllAnalysis()
        {
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);
           var dtAnalysis = new List<AnalysisDto>();
            string Query = @"SELECT        Analysis.AnalysisID, Analysis.AnalysisName, Analysis.Cost
FROM            Analysis 
";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {


                    while (Reader.Read()) {

                        dtAnalysis.Add(new AnalysisDto(
                            Reader.GetInt32(Reader.GetOrdinal("AnalysisID")),
                            Reader.GetString(Reader.GetOrdinal("AnalysisName")),
                            Reader.GetDouble(Reader.GetOrdinal("Cost"))

                            ));
                    
                    
                    
                    
                    }
                }
              


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtAnalysis;




        }






        static public bool ISExist(int AnalysisID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(ConnentionString.FixedConnectionString);

            string Query = @"
SELECT 
     Found=1 from Analysis
  where AnalysisID=@AnalysisID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", AnalysisID);
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
