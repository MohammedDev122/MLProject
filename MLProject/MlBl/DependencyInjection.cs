using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;
using MlBL.Validators;
using MlBL.Validators.AnalysisValidator;
using MlBL.Validators.ContainingValidator;
using MlBL.Validators.PackagesValidators;
using MlDAL.Interfaces;
using MlDAL.Repositories;


namespace MlBL
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Analysis
            services.AddScoped<IAnalysisService, AnalysisService>();
            services.AddScoped<IPackagesService, PackagesService>();
            services.AddScoped<IRecomendedPackages, RecommendedPackages>();

            //  services.AddScoped<IContainingService, ContainingService>();
            //  services.AddScoped<IAnalysisInPackages, AnalysisInPackages>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRegionService,  RegionService>();
            services.AddScoped<ILabService, LabService>();


            services.AddValidatorsFromAssemblyContaining<CreateAnalysisValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAnalysisValidator>();

            services.AddValidatorsFromAssemblyContaining<CreatePackageValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePackageValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateContainingValidator>();

            services.AddValidatorsFromAssemblyContaining<CityValidator>();
            services.AddValidatorsFromAssemblyContaining<RegionValidator>();
            services.AddValidatorsFromAssemblyContaining<LabValidator>();


            return services;
        }

        
        

    }
}
