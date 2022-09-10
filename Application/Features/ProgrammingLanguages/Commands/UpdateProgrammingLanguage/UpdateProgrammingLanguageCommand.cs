using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public ProgrammingLanguage NewProgrammingLanguage { get; set; }
        public string[] Roles { get; } = { "Admin", "Moderator" };

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper,
                                             ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                string oldName = _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenUpdated(request.Id)
                    .Result.Name;
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(
                    request.NewProgrammingLanguage.Name);


                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository
                    .UpdateAsync(mappedProgrammingLanguage);

                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper
                    .Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage,
                    options => options.Items.Add("OldName", oldName));

                return updatedProgrammingLanguageDto;
            }
        }
    }
}
