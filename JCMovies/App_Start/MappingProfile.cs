using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JCMovies.Dtos;
using JCMovies.Models;

namespace JCMovies.App_Start
{
    public class MappingProfile: Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            ////Mapper.CreateMap<Customer, CustomerDto>()
            ////    .ForMember(c => c.id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.id, opt => opt.Ignore());


            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //Mapper.CreateMap<Movie, MovieDto>()
            //    .ForMember(c => c.ID, opt => opt.Ignore());


            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.ID, opt => opt.Ignore());
        }
    }
}