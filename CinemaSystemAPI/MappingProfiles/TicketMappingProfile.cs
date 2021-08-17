using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.MappingProfiles
{
    public class TicketMappingProfile :Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(x => x.Start, y => y.MapFrom(z => z.Session.Start))
                .ForMember(x => x.End, y => y.MapFrom(z => z.Session.End))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Session.Room.Number));

            CreateMap<CreateTicketDto, Ticket>();
        }
    }
}
