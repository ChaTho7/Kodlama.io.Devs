using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<UpdateProgrammingLanguageCommand, ProgrammingLanguage>()
                .AfterMap((src, dest, ctx) =>
                {
                    if (ctx.Items.TryGetValue("OldName", out var oldName))
                    {
                        dest.Name = (string)oldName;
                    }

                    if (ctx.Items.TryGetValue("NewName", out var newName))
                    {
                        dest.Name = (string)newName;
                    }
                }).ReverseMap();

            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>()
                .ForMember(c => c.NewName, opt => opt.MapFrom(c => c.Name))
                .AfterMap((src, dest, ctx) =>
                {
                    if (ctx.Items.TryGetValue("OldName", out var oldName))
                    {
                        dest.OldName = (string)oldName;
                    }
                }).ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}
