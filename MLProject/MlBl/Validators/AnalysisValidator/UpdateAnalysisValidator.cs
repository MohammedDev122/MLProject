using FluentValidation;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Validators.AnalysisValidator
{
    public class UpdateAnalysisValidator : AbstractValidator<UpdateAnalysisDto>
    {
        public UpdateAnalysisValidator() 
        {
            RuleFor(x => x.Id)
                    .GreaterThan(0);

            RuleFor(x => x.AnalysisCost)
                    .GreaterThan(0);
        }
    }
}
