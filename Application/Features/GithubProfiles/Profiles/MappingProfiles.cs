using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Models;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
            CreateMap<UpdateGithubProfileCommand, GithubProfile>()
                .ForMember(c => c.Id, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["Id"]))
                .ForMember(c => c.ProfileUrl, opt => opt.MapFrom(c => c.NewGithubProfile.ProfileUrl))
                .ReverseMap();

            CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, UpdatedGithubProfileDto>()
                .ForMember(c => c.NewProfileUrl, opt => opt.MapFrom(c => c.ProfileUrl))
                .ForMember(c => c.OldProfileUrl, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["OldProfileUrl"]))
                .ReverseMap();

            CreateMap<IPaginate<GithubProfile>, GithubProfileListModel>().ReverseMap();
            CreateMap<GithubProfile, GithubProfileListDto>()
                .ForMember(c => c.UserFirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.UserLastName, opt => opt.MapFrom(c => c.User.LastName))
                .ReverseMap();
            CreateMap<GithubProfile, GithubProfileGetByUserIdDto>()
                .ForMember(c => c.UserFirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.UserLastName, opt => opt.MapFrom(c => c.User.LastName))
                .ReverseMap();
        }
    }
}
