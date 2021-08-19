using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.MappingProfiles
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomDto>();
        }
    }
}
