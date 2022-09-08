using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Frameworks.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;

        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository)
        {
            _frameworkRepository = frameworkRepository;
        }

        public async Task FrameworkNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Framework> result = await _frameworkRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Framework name exists.");
        }
        public async Task FrameworkNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<Framework> result = await _frameworkRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Framework name exists.");
        }

        public void FrameworkShouldExistWhenRequested(Framework? framework)
        {
            if (framework == null) throw new BusinessException("Requested framework doesn't exists.");
        }

        public void FrameworkShouldExistWhenDeleted(Framework? framework)
        {
            if (framework == null) throw new BusinessException("Requested framework doesn't exists.");
        }

        public async Task<Framework> FrameworkShouldExistWhenUpdated(int id)
        {
            IPaginate<Framework> result = await _frameworkRepository.GetListAsync(
                predicate: b => b.Id == id,
                include: m => m.Include(c => c.ProgrammingLanguage)
                );
            if (result == null) throw new BusinessException("Requested framework doesn't exists.");

            return result.Items.First();
        }

    }
}
