using FluentValidation;
using FluentValidation.Results;

using MlBL.DTOs;
using MlBL.Validators.PackagesValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Validators.ContainingValidator
{
    public class CreateContainingValidator:AbstractValidator<CreateContainingDTO>
    {

        public CreateContainingValidator()
        {
            RuleFor(x => x.PackageID)
                            .GreaterThan(0)
                            .WithMessage("Package ID is required.");
                            
            RuleFor(x => x.AnalysisID)
                            .GreaterThan(0)
                            .WithMessage("Analysis ID is required.");
        }
        static public ValidationResult ValidateData(CreatePackageDTO CPDTO)
        {
            CreatePackageValidator validator = new CreatePackageValidator();
            var Result = validator.Validate(CPDTO);

            return Result;
        }


    }
}
