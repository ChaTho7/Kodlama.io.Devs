using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Frameworks.Queries.GetByIdFramework
{
    public class GetByIdFrameworkQuery : IRequest<FrameworkGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdFrameworkQueryHandler : IRequestHandler<GetByIdFrameworkQuery, FrameworkGetByIdDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public GetByIdFrameworkQueryHandler(IFrameworkRepository frameworkRepository, IMapper mapper, FrameworkBusinessRules frameworkBusinessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
            }

            public async Task<FrameworkGetByIdDto> Handle(GetByIdFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework>? framework = await _frameworkRepository.GetListAsync(
                    predicate: b => b.Id == request.Id,
                    include: m => m.Include(c => c.ProgrammingLanguage)
                    );

                _frameworkBusinessRules.FrameworkShouldExistWhenRequested(framework.Items.First());

                FrameworkGetByIdDto frameworkGetByIdDto = _mapper.Map<FrameworkGetByIdDto>(framework.Items.First());

                return frameworkGetByIdDto;
            }
        }
    }
}
