using FluentValidation;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Validators
{
    public class CityValidator : AbstractValidator<CityDto>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("City name is required")
                .MaximumLength(30)
                .WithMessage("This too long name");
            
        }

    }

    public class RegionValidator : AbstractValidator<RegionDto>
    {
        public RegionValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Region name is required")
                .MaximumLength(30)
                .WithMessage("This too long name");

            RuleFor(r => r.CityId)
                .GreaterThan(0)
                .WithMessage("City Id must be greater than zero");

        }
    }

    public class LabValidator : AbstractValidator<LabDto> 
    {

        public LabValidator()
        { 
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Lab name is required")
                .MaximumLength(30)
                .WithMessage("This too long name");

            RuleFor(r => r.Address)
                .NotEmpty()
                .WithMessage("Lab Address is required")
                .MaximumLength(70)
                .WithMessage("Lab Address id too long");

            RuleFor(r => r.RegionId)
                .GreaterThan(0)
                .WithMessage("Region Id must be greater than zero");

            RuleFor(r => r.Status)
                .IsInEnum()
                .WithMessage("Invalid lab status");

            RuleFor(r => r.LabType)
                .IsInEnum()
                .WithMessage("Invalid lab type");

        }

    }

}
