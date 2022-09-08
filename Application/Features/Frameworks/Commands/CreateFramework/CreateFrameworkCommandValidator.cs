using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommandValidator : AbstractValidator<CreateFrameworkCommand>
    {
        public CreateFrameworkCommandValidator()
        {
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
