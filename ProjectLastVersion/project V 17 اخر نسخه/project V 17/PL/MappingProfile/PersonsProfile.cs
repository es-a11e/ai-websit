using AutoMapper;
using DAL.Entity;
using PL.Models;

namespace PL.MappingProfile
{
    public class PersonsProfile:Profile
    {
        public PersonsProfile()
        {
            CreateMap<PersonsViewModel,Person>().ReverseMap();
        }

    }
}
