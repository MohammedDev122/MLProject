using FluentValidation;
using MlBL.DTOs;

namespace MlBL.Validators.AnalysisValidator
{
    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisDto>
    {


        public CreateAnalysisValidator()
        {
            RuleFor(x => x.AnalysisName)
                            .NotEmpty()
                            .WithMessage("Analysis name is required.")
                            .MaximumLength(150)
                            .WithMessage("Analysis name cannot exceed 150 characters.");

            RuleFor(x => x.AnalysisCost)
                            .GreaterThan(0)
                            .WithMessage("Analysis cost must be greater than zero.");
        }
    }


    
}
