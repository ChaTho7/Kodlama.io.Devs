using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubProfiles.Queries.GetByUserIdGithubProfile
{
    public class GetByUserIdGithubProfileQuery : IRequest<GithubProfileGetByUserIdDto>
    {
        public int UserId { get; set; }

        public class GetByUserIdGithubProfileQueryHandler : IRequestHandler<GetByUserIdGithubProfileQuery, GithubProfileGetByUserIdDto>
        {
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public GetByUserIdGithubProfileQueryHandler(IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<GithubProfileGetByUserIdDto> Handle(GetByUserIdGithubProfileQuery request, CancellationToken cancellationToken)
            {
                GithubProfile githubProfile = await _githubProfileBusinessRules
                    .GitHubProfileShouldExistWhenRequest(request.UserId);

                GithubProfileGetByUserIdDto githubProfileGetByIdDto = _mapper
                    .Map<GithubProfileGetByUserIdDto>(githubProfile);

                return githubProfileGetByIdDto;
            }
        }
    }
}
