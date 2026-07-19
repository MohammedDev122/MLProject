using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MlBL.ClassToBeModified;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;
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

            services.AddValidatorsFromAssemblyContaining<CreateAnalysisValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAnalysisValidator>();
            services.AddScoped<IPackagesService, PackagesService>();

            services.AddValidatorsFromAssemblyContaining<CreatePackageValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePackageValidator>();
            services.AddScoped<IContainingService, ContainingService>();

            services.AddValidatorsFromAssemblyContaining<CreateContainingValidator>();
            services.AddScoped<IAnalysisInPackages, AnalysisInPackages>();
            services.AddScoped<IPackageRecomended, PackagesRecommended>();

            return services;
        }

        
        

    }
}
