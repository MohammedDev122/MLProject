using Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MlDAL.DbContexts;
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
    public class ContainingRepo : IContainingRepo
    {
        private readonly AppDbContext _context;

        public ContainingRepo (AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetIdAsync(int packageId, int analysisId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(packageId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisId);

            var contains = await _context.Containings
                .FirstOrDefaultAsync(c => c.PackageID == packageId && c.AnalysisID == analysisId);

            return contains.ContainID;
        }

        public async Task<bool> DeleteAsync(int containId)
        {
            
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(containId);

            var contain = await GetByIdAsync(containId);

            _context.Containings.Remove(contain);

            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteAsync(int packageId, int analysisId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(packageId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisId); 

            return
                await DeleteAsync(await GetIdAsync(packageId, analysisId));
        }

        public async Task<int> AddAsync(Containing entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Containings.Add(entity);

            await _context.SaveChangesAsync();

            return entity.ContainID;

        }

        public async Task<Containing?> GetByIdAsync(int containId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(containId);

            return await _context.Containings
                .Include(c => c.package)
                .Include(c => c.analysis)
                .FirstOrDefaultAsync(c => c.ContainID == containId);

        }

        public async Task<Dictionary<int, List<string>>> GetAll()
        {
            return await _context.Containings
                .Include(c => c.package)
                .Include(c => c.analysis)
                .Select(c => new
                {
                    c.ContainID,
                    PackageName = c.package.PackageName,
                    AnalysisName = c.analysis.AnalysisName
                })
                .ToDictionaryAsync(
                x => x.ContainID,
                x => new List<string>
                {
                    x.PackageName,
                    x.AnalysisName
                });
                
        }

        public async Task<int> AddAsync(int packageId, int analysisId)
        {
            var contain =
                new Containing(0, packageId, analysisId); // set id as zero till added

            contain.ContainID = await AddAsync(contain);

            return contain.ContainID;
        }


        /*
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
        */


    }
}
