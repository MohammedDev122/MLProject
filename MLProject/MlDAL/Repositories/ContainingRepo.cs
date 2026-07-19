using Core.Models;
using Microsoft.Data.SqlClient;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Repositories
{
    public class ContainingRepo:IContainingRepo
    {
        string ConnectionString;

        public ContainingRepo()
        {

            ConnectionString = "Server=.;Database=DBCallCenterData;User ID=sa;password=123456;TrustServerCertificate=True;";

        }
        public async Task<int> AddAsync(Containing entity)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"
INSERT INTO [Contains]
           (PackageID
           ,AnalysisID
          )
     VALUES
           (@PackageID
           ,@AnalysisID
           )
		   select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", entity.PackageID);

            command.Parameters.AddWithValue("@AnalysisID", entity
                .AnalysisID);


            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    entity.ContainID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return entity.ContainID;

        }


        public async Task<bool> UpdateAsync(Containing entity)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"UPDATE [Contains]
   SET PackageID = @PackageID
      ,AnalysisID = @AnalysisID
     
 WHERE ContainID=@ContainID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", entity.PackageID);
            command.Parameters.AddWithValue("@AnalysisID", entity.AnalysisID);

            command.Parameters.AddWithValue("@ContainID", entity.ContainID);



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


        public async Task<bool> DeleteAsync(int id)
        {

            bool Delete = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"Delete from [Contains]
 WHERE ContainID=@ContainID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ContainID",id);


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


        public async Task<Containing?> GetByIdAsync(int id)
        {
            Containing Contain = new Containing();
            bool Found = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"
SELECT 
       PackageID,
       AnalysisID
  FROM [Contains]
  where ContainID=@ContainID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ContainID", id);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    Contain.PackageID = Convert.ToInt32(Reader["PackageID"]);

                    Contain.AnalysisID = Convert.ToInt32(Reader["AnalysisID"]);
                    Contain.ContainID = id;
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return (Found) ? Contain : null ;
        }

        public async Task<Dictionary<int, List<string>>> GetAll()
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, List<string>> dtContains = new Dictionary<int, List<string>>();
            List<string> ContainersObjects = new List<string>();
            string Query = @"SELECT        [Contains].ContainID, Packages.PackageName, Analysis.AnalysisName
FROM            [Contains] INNER JOIN
                         Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                         Analysis ON [Contains].AnalysisID = Analysis.AnalysisID

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
                        ContainersObjects.Add(Reader.GetString(1));
                        ContainersObjects.Add(Reader.GetString(2));

                        dtContains.Add(Reader.GetInt32(0),ContainersObjects);
                        ContainersObjects = new List<string>();
                    }
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtContains;


        }

        public async Task<List<Containing>> GetAllAsync() {

            return null;



        }


        public async Task<bool> ExistsAsync(int id) {


            bool Exist = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"
SELECT 
     Found=1 from [Contains]
  where ContainID=@ContainID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ContainID", id);
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
            return  Exist;






        }

        public async Task<bool> DeleteAllPackage_SContains(int PackageID)
        {


            bool Delete = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"Delete from [Contains]
 WHERE PackageID=@PackageID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", PackageID);


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
        public async Task<bool> DeleteAllAnalysis_SContains(int AnalysisID)
        {
            bool Delete = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"Delete from [Contains]
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

        public async Task<Dictionary<int, List<int>>> GetAllAnalysis_Packages()
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, List<int>> Result = new Dictionary<int, List<int>>();
            string Query = @"SELECT        Packages.PackageID, Analysis.AnalysisID
    FROM            [Contains] INNER JOIN
                             Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                             Analysis ON [Contains].AnalysisID = Analysis.AnalysisID 							 order by analysisID

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
                        int packageID = (int)Reader["PackageID"];
                        int AnalysisID = (int)Reader["AnalysisID"];

                        if (!Result.ContainsKey(AnalysisID))
                        {
                            Result[AnalysisID] = new List<int>();
                        }

                        Result[AnalysisID].Add(packageID);
                    }
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return Result;
        }

        public async Task<Dictionary<int, List<int>>> GetAllPackagesAnalysis()
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, List<int>> Result = new Dictionary<int, List<int>>();
            string Query = @"SELECT        Packages.PackageID, Analysis.AnalysisID
    FROM            [Contains] INNER JOIN
                             Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                             Analysis ON [Contains].AnalysisID = Analysis.AnalysisID

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
                        int packageID = (int)Reader["PackageID"];
                        int AnalysisID = (int)Reader["AnalysisID"];

                        if (!Result.ContainsKey(packageID))
                        {
                            Result[packageID] = new List<int>();
                        }

                        Result[packageID].Add(AnalysisID);
                    }
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return Result;
        }
        public async Task<Dictionary<int, List<string>>> GetAllPackage_SContain(int PackageID) {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, List<string>> dtContains = new Dictionary<int, List<string>>();
            List<string>PackageContaining=new List<string>();
            string Query = @"SELECT        [Contains].ContainID, Packages.PackageName, Analysis.AnalysisName
FROM            [Contains] INNER JOIN
                         Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                         Analysis ON [Contains].AnalysisID = Analysis.AnalysisID
						 where Packages.PackageID=@PackageID

";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", PackageID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        PackageContaining.Add(Reader.GetString(1));
                        PackageContaining.Add(Reader.GetString(2));
                        dtContains.Add(Reader.GetInt32(0),PackageContaining);
                        PackageContaining=new List<string>();
                    }

                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtContains;

        }
        public async Task<double> GetAllPackage_SContainCost(int PackageID)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            double Cost = 0;
            string Query = @"SELECT   SUM(Analysis.Cost) as Cost
FROM            [Contains] INNER JOIN
                         Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                         Analysis ON [Contains].AnalysisID = Analysis.AnalysisID
						 where Packages.PackageID=@PackageID

";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", PackageID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    Cost = Convert.ToDouble(Reader["Cost"]);


                }



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Cost;

        }
        public async Task<Dictionary<int, List<string>>> GetAllAnalysis_SContainiers(int AnalysisID) {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, List<string>> dtContains = new Dictionary<int, List<string>>();
            List<string>Containers=new List<string>();
            string Query = @"SELECT        [Contains].ContainID, Packages.PackageName, Analysis.AnalysisName
FROM            [Contains] INNER JOIN
                         Packages ON [Contains].PackageID = Packages.PackageID INNER JOIN
                         Analysis ON [Contains].AnalysisID = Analysis.AnalysisID
						 where Packages.AnalysisID=@AnalysisID

";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", AnalysisID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    while (Reader.Read()) {


                        Containers.Add(Reader.GetString(1));
                        Containers.Add(Reader.GetString(2));
                        dtContains.Add(Reader.GetInt32(0), Containers);
                        Containers = new List<string>();





                    }


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtContains;
        }

        public async Task<bool> ISExist(int AnalysisID, int PackageID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"select found=1 from [Contains]
where AnalysisID=@AnalysisID and PackageID=@PackageID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@AnalysisID", AnalysisID);
            command.Parameters.AddWithValue("@PackageID", PackageID);

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
