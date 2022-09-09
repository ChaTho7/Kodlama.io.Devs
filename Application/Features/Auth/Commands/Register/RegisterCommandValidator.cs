using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Email).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Password).NotEmpty();
        }
    }
}
