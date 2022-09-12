using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Commands.DeleteFramework;
using Application.Features.Frameworks.Commands.UpdateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Models;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Frameworks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();
            CreateMap<Framework, DeleteFrameworkCommand>().ReverseMap();

            CreateMap<Framework, CreatedFrameworkDto>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<Framework, DeletedFrameworkDto>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<Framework, UpdatedFrameworkDto>()
                .ForMember(c => c.NewName, opt => opt.MapFrom(c => c.Name))
                .ForMember(c => c.NewProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ForMember(c => c.OldName, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["OldName"]))
                .ForMember(c => c.OldProgrammingLanguageName, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["OldProgrammingLanguageName"]))
                .ReverseMap();

            CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();
            CreateMap<Framework, FrameworkListDto>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<Framework, FrameworkGetByIdDto>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
        }
    }
}
