using AutoMapper;
using Movie.Dtos;
using Movie.Models;

namespace Movie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to dto
            Mapper.CreateMap<MovieModel, MovieDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            // Dto to model
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, MovieModel>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<RentalDto, Rental>();
        }
    }
}