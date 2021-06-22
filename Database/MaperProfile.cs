using AutoMapper;
using BotMongoII.Models;
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
        }

    }
}
