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

namespace Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand : IRequest<CreatedFrameworkDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public CreateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper,
                                             FrameworkBusinessRules frameworkBusinessRules, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenInserted(request.Name);

                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework createdFramework = await _frameworkRepository.AddAsync(mappedFramework);
                createdFramework.ProgrammingLanguage = await _programmingLanguageRepository
                    .GetAsync(p => p.Id == createdFramework.ProgrammingLanguageId);

                CreatedFrameworkDto createdFrameworkDto = _mapper.Map<CreatedFrameworkDto>(createdFramework);

                return createdFrameworkDto;
            }
        }
    }
}
