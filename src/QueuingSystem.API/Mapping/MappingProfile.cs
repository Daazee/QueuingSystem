using AutoMapper;
using QueuingSystem.Models;
using QueuingSystem.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueuingSystem.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTOs
            CreateMap<Queues, QueuesDTO>()
                  .ForMember(dest => dest.StatusDisplay, opt => opt.MapFrom(src => src.Status == 0 ? "Draft" : "Closed" ));

            // DTOs to Domain
            CreateMap<QueuesDTO, Queues>();
        }
    }
}
