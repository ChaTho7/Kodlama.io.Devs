using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IUserRepository _userRepository;

        public GithubProfileBusinessRules(IGithubProfileRepository githubProfileRepository, IUserRepository userRepository)
        {
            _githubProfileRepository = githubProfileRepository;
            _userRepository = userRepository;
        }

        public async Task GithubProfileCanNotAddMoreThanOnce(int userId)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(b => b.UserId == userId);
            if (result.Items.Any()) throw new BusinessException("GithubProfile has been already added. " +
                                                                "Please delete old one first.");
        }

        public async Task UserShouldExistWhenAdd(int userId)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(
                predicate: b => b.Id == userId
                );
            if (result == null) throw new BusinessException("Requested user doesn't exists.");
        }

        public async Task<GithubProfile> GitHubProfileShouldExistWhenRequest(int userId)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(
                predicate: b => b.UserId == userId,
                include: m => m.Include(c => c.User)
            );
            if (result.Items.Count == 0) throw new BusinessException("Requested profile doesn't exists.");

            return result.Items.First();
        }

        public async Task<GithubProfile> GitHubProfileShouldExistWhenDelete(int userId)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(
                predicate: b => b.UserId == userId
            );
            if (result == null) throw new BusinessException("Requested profile doesn't exists.");

            return result.Items.First();
        }

        public async Task<GithubProfile> GitHubProfileShouldExistWhenUpdate(int userId)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(
                predicate: b => b.UserId == userId
            );
            if (result == null) throw new BusinessException("Requested profile doesn't exists.");

            return result.Items.First();
        }
    }
}
