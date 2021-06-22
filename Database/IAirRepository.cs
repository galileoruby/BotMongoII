using BotMongoII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public interface IAirRepository
    {
        Task<AirMongoDB> GetAirMongoById(string id);

        Task<List<AirMongoDB>> All();
        Task<AirMongoDB> AddNewAir(AirMongoModel currentAir);

        Task<AirMongoDB> UpdateAir(string id, AirMongoModel updateRecord);
        Task<AirMongoDB> AddAmenities(string id, List<string> Amenities);



        void RemoveAir(String id);



    }
}
