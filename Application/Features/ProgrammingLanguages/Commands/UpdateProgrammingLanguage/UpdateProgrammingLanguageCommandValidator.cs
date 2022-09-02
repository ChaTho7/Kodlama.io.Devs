﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.OldName).NotEmpty();
            RuleFor(c => c.NewName).NotEmpty();
        }
    }
}
