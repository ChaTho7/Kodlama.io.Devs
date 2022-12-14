using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
        }
        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programmingLanguage doesn't exists.");
        }

        public void ProgrammingLanguageShouldExistWhenDeleted(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programmingLanguage doesn't exists.");
        }

        public async Task<ProgrammingLanguage> ProgrammingLanguageShouldExistWhenUpdated(int id)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Requested programmingLanguage doesn't exists.");

            return result.Items.First();
        }

    }
}
