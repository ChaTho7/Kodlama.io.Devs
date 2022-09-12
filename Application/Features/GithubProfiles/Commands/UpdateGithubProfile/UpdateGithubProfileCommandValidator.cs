using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommandValidator : AbstractValidator<UpdateGithubProfileCommand>
    {
        public UpdateGithubProfileCommandValidator()
        {
            RuleFor(c => c.Identity).NotEmpty();
            RuleFor(c => c.NewGithubProfile.UserId).NotEmpty();
        }
    }
}
