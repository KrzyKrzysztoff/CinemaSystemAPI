using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.MappingProfiles
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<Session, SessionDto>()
                .ForMember(x => x.Capcity, y => y.MapFrom(z => z.Room.Capcity))
                .ForMember(x => x.MovieCategory, y => y.MapFrom(z => z.Movie.Category))
                .ForMember(x => x.MovieLengthInMinutes, y => y.MapFrom(z => z.Movie.LengthInMinutes))
                .ForMember(x => x.MovieName, y => y.MapFrom(z => z.Movie.Name))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Room.Number))
                .ForMember(x => x.RequiredAge, y => y.MapFrom(z => z.Movie.RequiredAge));
        }
    }
}
