using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MlDAL.DbContexts;
using MlDAL.Interfaces;
using MlDAL.Repositories;

namespace MlDAL
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfraStructure 
                        (this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TestConnection")));

            services.AddScoped<IAnalysisRepository, AnalysisRepo>();
            services.AddScoped<IPackagesRepo, PackageRepo>();
            services.AddScoped<IContainingRepo, ContainingRepo>();
            return services;
        }
    }
}
