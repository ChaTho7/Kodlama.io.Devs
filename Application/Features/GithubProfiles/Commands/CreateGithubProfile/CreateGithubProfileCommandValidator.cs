using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommandValidator : AbstractValidator<CreateGithubProfileCommand>
    {
        public CreateGithubProfileCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.ProfileUrl).NotEmpty();
        }
    }
}
