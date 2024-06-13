using AutoMapper;
using global::PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using PL.ViewModels;

namespace PL.MappingProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleViewModel, IdentityRole>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.RoleName))
                .ReverseMap();
        }
    }
}

