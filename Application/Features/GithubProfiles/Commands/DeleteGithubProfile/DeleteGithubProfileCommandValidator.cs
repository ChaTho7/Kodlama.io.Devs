using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandValidator : AbstractValidator<DeleteGithubProfileCommand>
    {
        public DeleteGithubProfileCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
