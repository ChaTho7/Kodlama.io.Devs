using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserForRegisterDto, User>()
                .ForMember(c => c.PasswordHash, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["PasswordHash"]))
                .ForMember(c => c.PasswordSalt, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["PasswordSalt"]))
                .AfterMap((src, dest) =>
                {
                    dest.Status = true;
                    dest.AuthenticatorType = AuthenticatorType.None;
                })
                .ReverseMap();
        }
    }
}
