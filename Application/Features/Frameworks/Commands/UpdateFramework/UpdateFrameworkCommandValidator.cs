using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommandValidator : AbstractValidator<UpdateFrameworkCommand>
    {
        public UpdateFrameworkCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.NewFramework.Name).NotEmpty();
            RuleFor(c => c.NewFramework.ProgrammingLanguageId).NotEmpty();
        }
    }
}
