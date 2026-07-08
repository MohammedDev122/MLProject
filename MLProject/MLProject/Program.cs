using Microsoft.EntityFrameworkCore;
using MlBL.Services;
using MlBL.ServicesInterfaces;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using MlDAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TestConnection"));
});
builder.Services.AddScoped<IAnalysisRepository, AnalysisRepo>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
