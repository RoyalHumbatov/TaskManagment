using AutoMapper;
using TaskManagment.DTO;
using TaskManagment.Entities;

namespace TaskManagment.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Person,PersonDto>().ReverseMap();
        }
    }
}
