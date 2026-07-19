using FluentValidation;
using FluentValidation.Results;

using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Validators.PackagesValidators
{
    public class CreatePackageValidator : AbstractValidator<CreatePackageDTO>
    {
        public CreatePackageValidator()
        {
            RuleFor(x => x.PackageName)
                            .NotEmpty()
                            .WithMessage("Package name is required.")
                            .MaximumLength(150)
                            .WithMessage("Package name cannot exceed 150 characters.");

            RuleFor(x => x.PackageCost)
                            .GreaterThan(0)
                            .WithMessage("Package cost must be greater than zero.");
            RuleFor(x => Convert.ToInt32(x.PackageGender)).GreaterThan(0).
                WithMessage("Package Gender Enum Values Start From 1 to 3!").LessThan(4)
                .WithMessage("Package Gender Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.PackageType)).GreaterThan(0).
                WithMessage("Package Type Enum Values Start From 1 to 3!").LessThan(4)
              .WithMessage("Package Type Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.packageStatus)).GreaterThan(0).
                WithMessage("Package Status Enum Values Start From 1 to 3!").LessThan(4)
            .WithMessage("Package Status Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.VisitType)).GreaterThan(0)
                .WithMessage("VisitType Enum Values Start From 1 to 2!").LessThan(3)
               .WithMessage("VisitType Enum Values Start From 1 to 2!");
        }




       static  public ValidationResult ValidateData(CreatePackageDTO CPDTO)
        {
            CreatePackageValidator validator=new CreatePackageValidator();
            var Result = validator.Validate(CPDTO);
            
            return Result;
        }
    }
}
