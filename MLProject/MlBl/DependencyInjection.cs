using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MlBL.Interfaces;
using MlBL.Services;
using MlBL.Validators;
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


            return services;
        }

        
        

    }
}
