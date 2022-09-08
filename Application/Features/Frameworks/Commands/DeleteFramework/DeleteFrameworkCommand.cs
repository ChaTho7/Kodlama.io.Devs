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

namespace Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand : IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }
        public class DeleteFrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public DeleteFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper,
                                             FrameworkBusinessRules frameworkBusinessRules, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<DeletedFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedFramework = _mapper.Map<Framework>(request);
                _frameworkBusinessRules.FrameworkShouldExistWhenDeleted(mappedFramework);

                Framework deletedFramework = await _frameworkRepository.DeleteAsync(mappedFramework);
                deletedFramework.ProgrammingLanguage = await _programmingLanguageRepository
                    .GetAsync(p => p.Id == deletedFramework.ProgrammingLanguageId);

                DeletedFrameworkDto deletedFrameworkDto = _mapper.Map<DeletedFrameworkDto>(deletedFramework);

                return deletedFrameworkDto;
            }
        }
    }
}
