using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MlBL.DTOs;
using MlBL.Services;
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

    Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));  

    Console.WriteLine("Start");

    var analyses = await analysisRepo.GetAllAsync();

    Console.WriteLine("updated successfully");

   foreach (var analysis in analyses) 
         Console.WriteLine($"Id: {analysis.AnalysisId}, Name: {analysis.AnalysisName}, Cost: {analysis.Cost}");
   


async Task<List<AnalysisDto>> GetAll (AnalysisRepo repo)
{
    var service = new AnalysisService(repo);
    return await service.GetAllAsync();

}

async Task<AnalysisDto> Update (AnalysisRepo repo, UpdateAnalysisDto updateAnalysisDto)
{
    var service = new AnalysisService(repo);
    return await service.UpdateAsync(updateAnalysisDto);

}



async Task <AnalysisDto> Add(AnalysisRepo repo, CreateAnalysisDto createAnalysisDto)
{
    var service = new AnalysisService(repo);
    return await service.AddAsync(createAnalysisDto);

}