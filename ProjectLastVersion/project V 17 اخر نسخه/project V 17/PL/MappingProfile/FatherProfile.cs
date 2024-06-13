using AutoMapper;
using DAL.Entity;
using PL.Models;

namespace PL.MappingProfile
{
    public class FatherProfile : Profile
    {

        public FatherProfile()
        {
            CreateMap<FatherViewModel,Father>().ReverseMap();
        }
    }
}
