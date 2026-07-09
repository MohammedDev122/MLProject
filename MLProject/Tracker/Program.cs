using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MlDAL.DbContexts;
using MlDAL.Repositories;



    // Build Configuration
    IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

    /* foreach (var item in configuration.AsEnumerable())
     {
         Console.WriteLine($"{item.Key} = {item.Value}");
     }
     Console.WriteLine(Directory.GetCurrentDirectory());*/

    string? connectionString = configuration.GetConnectionString("TestConnection");

    if (connectionString == null)
    {
        Console.WriteLine("Connection string is NULL");
        return;
    }


    //A configuration builder for EF Core
    DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .Options;

    using var context = new AppDbContext(options);
    Console.WriteLine("Connected successfully");
    var analysisRepo = new AnalysisRepo(context);

    Console.WriteLine("Start");
    var analyses = await GetAll(context);
    Console.WriteLine("Data got");

    if (analyses.Count > 0)
    {
        foreach (Analysis analysis in analyses)
        {
            Console.WriteLine($"Id: {analysis.AnalysisID}, Name: {analysis.AnalysisName}, Cost: {analysis.Cost}");
        }
    }
    else
    {
        Console.WriteLine("Analysis is empty");
    }


async Task<List<Analysis>> GetAll (AppDbContext context)
{
   return await analysisRepo.GetAllAsync();

}