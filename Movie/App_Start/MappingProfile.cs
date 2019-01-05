using AutoMapper;
using Movie.Dtos;
using Movie.Models;

namespace Movie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieModel, MovieDto>();
            Mapper.CreateMap<MovieDto, MovieModel>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}