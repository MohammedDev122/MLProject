using FluentValidation;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace MlBL.Validators.PackagesValidators
{
    public class UpdatePackageValidator:AbstractValidator<UpdatedPackageDto>
    {




        public UpdatePackageValidator() {

            RuleFor(x => x.PackageID).GreaterThan(0)
                .WithMessage("Must Provide PackageID!");
            RuleFor(x => x.PackageCost)
                            .GreaterThan(0)
                            .WithMessage("Package cost must be greater than zero.");
            RuleFor(x => Convert.ToInt32(x.PackageGender))
                .GreaterThan(0).
                WithMessage("Package Gender Enum Values Start From 1 to 3!")
                .LessThan(4)
                .WithMessage("Package Gender Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.PackageType))
                .GreaterThan(0).
                WithMessage("Package Type Enum Values Start From 1 to 3!")
                .LessThan(4)
              .WithMessage("Package Type Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.packageStatus))
                .GreaterThan(0).
                WithMessage("Package Status Enum Values Start From 1 to 3!")
                .LessThan(4)
            .WithMessage("Package Status Enum Values Start From 1 to 3!");
            RuleFor(x => Convert.ToInt32(x.VisitType))
                .GreaterThan(0)
                .WithMessage("VisitType Enum Values Start From 1 to 2!")
                .LessThan(3)
               .WithMessage("VisitType Enum Values Start From 1 to 2!");


        }
        static public ValidationResult ValidateData(UpdatedPackageDto CPDTO)
        {
            UpdatePackageValidator validator = new UpdatePackageValidator();
            var Result = validator.Validate(CPDTO);

            return Result;
        }
    }

}
