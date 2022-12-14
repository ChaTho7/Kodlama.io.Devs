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
using Core.Application.Pipelines.Authorization;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommand : IRequest<UpdatedGithubProfileDto>, ISecuredByIdentityRequest
    {
        public GithubProfile NewGithubProfile { get; set; }
        public int Identity { get; set; }
        public string[] SuperRoles { get; } = { "Admin" };

        public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public UpdateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile oldGithubProfile = await _githubProfileBusinessRules
                    .GitHubProfileShouldExistWhenUpdate(request.Identity);

                request.NewGithubProfile.Id = oldGithubProfile.Id;

                GithubProfile updatedGithubProfile = await _githubProfileRepository.UpdateAsync(request.NewGithubProfile);
                UpdatedGithubProfileDto updatedGithubProfileDto = _mapper.Map<UpdatedGithubProfileDto>(updatedGithubProfile,
                    options =>
                    {
                        options.Items.Add("OldProfileUrl", oldGithubProfile.ProfileUrl);
                    });

                return updatedGithubProfileDto;
            }
        }
    }
}
