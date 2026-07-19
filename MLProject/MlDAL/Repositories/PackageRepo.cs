using Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Repositories
{
    public class PackageRepo:IPackagesRepo
    {
        string ConnectionString;

        public PackageRepo()
        {

            ConnectionString = "Server=.;Database=DBCallCenterData;User ID=sa;password=123456;TrustServerCertificate=True;";

        }

        // packages
        public async Task<Packages>? GetByIdAsync(int PackageID)
        {
            Packages Package = new Packages();
            bool Found = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);


            string Query = @"
SELECT 
       Cost,
       PackageName,
       PackageTypeID,
       PackagePhoto,
PackageGenderID,
VisitTypeID,
PackageStatusID
  FROM Packages
  where PackageID=@PackageID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", PackageID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {



                    Package.PackageCost = Convert.ToDouble(Reader["Cost"]);

                    Package.PackageName = Convert.ToString(Reader["PackageName"]);
                    Package.PackageType = (enPackageType)Reader["PackageTypeID"];
                    Package.PackagePhotoPath = Convert.ToString(Reader["PackagePhoto"]);

                   Package.PackageGender = (enPackageGender)Reader["PackageGenderID"];
                    Package.VisitType = (enVisitType)Reader["VisitTypeID"];
                    Package.packageStatus = (enPackageStatus)Reader["PackageStatusID"];
                    Package.PackageID = PackageID;
                    Found = true;


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return Found? Package:null;




        }
         public async Task<int> AddAsync(Packages Package)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"
INSERT INTO Packages
           (Cost
           ,PackageName
           ,PackageTypeID
           ,PackagePhoto,
PackageGenderID,
VisitTypeID
,PackageStatusID)
     VALUES
           (@Cost
           ,@PackageName
           ,@PackageTypeID
           ,@PackagePhoto,
@PackageGenderID
,@VisitTypeID,
@PackageStatusID)
		   select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@Cost", Package.PackageCost);


            command.Parameters.AddWithValue("@PackageName",Package.PackageName);


            command.Parameters.AddWithValue("@PackageTypeID",Convert.ToInt32(Package.PackageType));

            command.Parameters.AddWithValue("@PackagePhoto",Package.PackagePhotoPath);
            command.Parameters.AddWithValue("@PackageGenderID", Convert.ToInt32(Package.PackageGender));
            command.Parameters.AddWithValue("@VisitTypeID", Convert.ToInt32(Package.VisitType));
            command.Parameters.AddWithValue("@PackageStatusID", Convert.ToInt32(Package.packageStatus));

            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    Package.PackageID = InsertedID;





                }
              





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Package.PackageID;




        }
         public async Task <bool> UpdateAsync(Packages Package)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"UPDATE packages
   SET Cost = @Cost
      ,PackageName = @PackageName
      ,PackageTypeID = @PackageTypeID
      ,PackagePhoto = @PackagePhoto
      ,PackageGenderID = @PackageGenderID

      ,VisitTypeID = @VisitTypeID
      ,PackageStatusID = @PackageStatusID
 WHERE PackageID=@PackageID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PackageID", Package.PackageID);
            command.Parameters.AddWithValue("@Cost", Package.PackageCost);
            command.Parameters.AddWithValue("@PackageName", Package.PackageName);
            command.Parameters.AddWithValue("@PackageTypeID", Convert.ToInt32(Package.PackageType));
            command.Parameters.AddWithValue("@PackagePhoto", Package.PackagePhotoPath);
            command.Parameters.AddWithValue("@PackageGenderID", Convert.ToInt32(Package.PackageGender));
            command.Parameters.AddWithValue("@VisitTypeID", Convert.ToInt32(Package.VisitType));
            command.Parameters.AddWithValue("@PackageStatusID", Convert.ToInt32(Package.packageStatus));



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
         public async Task<bool> DeleteAsync(int PackageID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"Delete from packages
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
         public async Task<List<Packages>> GetAllAsync()
        {
            List<Packages>packagesList=new List<Packages> ();
            Packages Package = new Packages();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            DataTable dtPackages = new DataTable();
            string Query = @"SELECT        Packages.PackageID, Packages.PackageName, Packages.Cost, Packages.PackageTypeID as PackageType,
Packages.PackageGenderID, Packages.VisitTypeID as VisitType, Packages.PackageStatusID, Packages.PackagePhoto
FROM            Packages INNER JOIN
                         PackageTypes ON Packages.PackageTypeID = PackageTypes.PackageTypeID INNER JOIN
                         PackageStatus ON Packages.PackageStatusID = PackageStatus.PackageStatusID INNER JOIN
                         PackageGenders ON Packages.PackageGenderID = PackageGenders.PackageGenderID INNER JOIN
                         VisitTypes ON Packages.VisitTypeID = VisitTypes.VisitTypeID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read()) { 
                Package.PackageID = Reader.GetInt32(0);
                    Package.PackageName = Reader.GetString(1);
                    Package.PackageCost=Convert.ToDouble(Reader.GetDecimal(2));
                    Package.PackageType = (enPackageType)Reader.GetInt32(3);
                    Package.PackageGender = (enPackageGender)Reader.GetInt32(4);
                    Package.VisitType=(enVisitType)Reader.GetInt32(5);
                    Package.packageStatus=(enPackageStatus)Reader.GetInt32(6);
                    Package.PackagePhotoPath = Reader.GetString(7);
                packagesList.Add(Package);
                    Package = new Packages();
                
                
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return  packagesList;




        }

         public async Task<Dictionary<int, double>> GetAllPackagesCostAsync()
        {
            int packageID = -1;
            double Cost = 0;

            SqlConnection Connection = new SqlConnection(ConnectionString);
            Dictionary<int, double> Result = new Dictionary<int, double>();
            string Query = @"SELECT        PackageID,Cost FROM            Packages;
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

                        packageID = (int)Reader["PackageID"];
                        Cost = Convert.ToDouble(Reader["Cost"]);


                        if (!Result.ContainsKey(packageID))
                        {
                            Result[packageID] = Cost;
                        }
                    }


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Result;




        }



         public async Task<bool> ExistsAsync(int PackageID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = @"
SELECT 
     Found=1 from packages
  where PackageID=@PackageID";
            SqlCommand command = new SqlCommand(Query, Connection);
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
