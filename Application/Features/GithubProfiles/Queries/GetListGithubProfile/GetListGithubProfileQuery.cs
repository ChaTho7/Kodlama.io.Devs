using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubProfiles.Queries.GetListGithubProfile
{
    public class GetListGithubProfileQuery : IRequest<GithubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileListModel>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;

            public GetListGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
            }

            public async Task<GithubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubProfile> githubProfiles = await _githubProfileRepository.GetListAsync(
                    include: m => m.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                GithubProfileListModel mappedGithubProfileListModel = _mapper.Map<GithubProfileListModel>(githubProfiles);

                return mappedGithubProfileListModel;
            }
        }
    }
}
