using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;

namespace Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommand : IRequest<CreatedGithubProfileDto>
    {
        public int UserId { get; set; }
        public string ProfileUrl { get; set; }

        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public CreateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, 
                IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                await _githubProfileBusinessRules.UserShouldExistWhenAdd(request.UserId);
                await _githubProfileBusinessRules.GithubProfileCanNotAddMoreThanOnce(request.UserId);

                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile createdGithubProfile = await _githubProfileRepository.AddAsync(mappedGithubProfile);

                CreatedGithubProfileDto createdGithubProfileDto = _mapper.Map<CreatedGithubProfileDto>(createdGithubProfile);

                return createdGithubProfileDto;
            }
        }
    }
}
