using AutoMapper;
using DAL.Entity;
using PL.Models;

namespace PL.MappingProfile
{
    public class MotherProfile:Profile
    {

        public MotherProfile()
        {
            CreateMap<MotherViewModel, Mother>().ReverseMap();
        }
    }
}
