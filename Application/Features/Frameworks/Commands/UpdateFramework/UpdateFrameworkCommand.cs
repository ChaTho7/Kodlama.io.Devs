using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Rules;

namespace Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand : IRequest<UpdatedFrameworkDto>
    {
        public Framework NewFramework { get; set; }

        public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdatedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public UpdateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper,
                                             FrameworkBusinessRules frameworkBusinessRules, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<UpdatedFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework oldFramework = _frameworkBusinessRules.FrameworkShouldExistWhenUpdated(request.NewFramework.Id).Result;
                await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenUpdated(
                    request.NewFramework.Name);

                ProgrammingLanguage? newProgrammingLanguage = await _programmingLanguageRepository.GetAsync(
                    p => p.Id == request.NewFramework.ProgrammingLanguageId);

                Framework updatedFramework = await _frameworkRepository.UpdateAsync(request.NewFramework);
                updatedFramework.ProgrammingLanguage = newProgrammingLanguage;

                UpdatedFrameworkDto updatedFrameworkDto = _mapper.Map<UpdatedFrameworkDto>(updatedFramework,
                    options =>
                    {
                        options.Items.Add("OldProgrammingLanguageName", oldFramework.ProgrammingLanguage.Name);
                        options.Items.Add("OldName", oldFramework.Name);
                    });

                return updatedFrameworkDto;
            }
        }
    }
}
