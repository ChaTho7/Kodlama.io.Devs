using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommandValidator : AbstractValidator<DeleteFrameworkCommand>
    {
        public DeleteFrameworkCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
