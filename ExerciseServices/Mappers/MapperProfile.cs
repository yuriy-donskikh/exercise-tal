using System;
using AutoMapper;
using Data = ExerciseData.Entities;
using Models = ExerciseModel.Models;

namespace ExerciseServices.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Data.Room, Models.Room>()
                ;
            CreateMap<Data.RoomTime, Models.RoomTime>()
                .ForMember(dst=>dst.Available, opt=>opt.MapFrom(src=>false))
                ;
            CreateMap<Models.Room, Data.Room>()
                .ForMember(dst => dst.RoomId, opt => opt.Ignore())
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => new TimeSpan(9,0,0)))
                .ForMember(dst => dst.End, opt => opt.MapFrom(src => new TimeSpan(17, 0, 0)))
                ;
            CreateMap<Models.RoomTime, Data.RoomTime>()
                .ForMember(dst => dst.RoomId, opt => opt.Ignore())
                ;
        }
    }
}
