using AutoMapper;
using Sat.Recruitment.Api.DTO;
using Sat.Recruitment.Api.Extensions;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Domain.Enums;
using System;

namespace Sat.Recruitment.Api.Mappings
{
    public class UserViewMapping : Profile
    {
        public UserViewMapping()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => MappingExtension.NormalizeEmail(source.Email)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(source => source.Phone))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(source => source.UserType))
                .ForMember(dest => dest.Money, opt => opt.MapFrom(x => MappingExtension.GetMoney((UserType)Enum.Parse(typeof(UserType), x.UserType), decimal.Parse(x.Money))));
        }
    }
}
