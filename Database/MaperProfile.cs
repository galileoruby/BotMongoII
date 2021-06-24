using AutoMapper;
using BotMongoII.Models;
using BotMongoII.Models.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public class MaperProfile: Profile
    {
        //all the representationsss are here

        public MaperProfile()
        {
            CreateMap<AirMongoDB, AirMongoModel>().ReverseMap();

             
            CreateMap<ZipLoc, ZipLocModel>().ReverseMap();

            CreateMap<ZipMongoModel, ZipMongoDB>()
                        .ForMember(a => a.Loc, b => b.MapFrom(c => c.Loc))
                        .ReverseMap();


        }

    }
}
