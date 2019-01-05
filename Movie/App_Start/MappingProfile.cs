using AutoMapper;
using Movie.Dtos;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}