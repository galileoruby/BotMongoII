using AutoMapper;
using BotMongoII.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public class AirRepository : IAirRepository
    {

        private readonly IMongoCollection<AirMongoDB> air;
        private readonly IMapper _mapper;

        public AirRepository(IConfiguration config, IMapper mapper)
        {
            MongoClient client = new MongoClient(config.GetSection("Database").GetSection("Conection").Value);
            IMongoDatabase database = client.GetDatabase(config.GetSection("Database").GetSection("Name").Value);

            air = database.GetCollection<AirMongoDB>("airmongo");
            _mapper = mapper;

        }

        public async Task<AirMongoDB> AddNewAir(AirMongoModel currentAir)
        {
            var model = _mapper.Map<AirMongoDB>(currentAir);
             await air.InsertOneAsync(model);

            return model;             

        }

        public async Task<List<AirMongoDB>> All()
        {
            var result = await air.Find(air => true).ToListAsync();
           return result;

        }

        public async Task<AirMongoDB> GetAirMongoById(string id)
        {
            var filter = Builders<AirMongoDB>.Filter.Eq("Id", id);
            var result = await air.Find(filter).FirstOrDefaultAsync();

            return result;


        }

        public async Task< AirMongoDB> UpdateAir(string id, AirMongoModel updateRecord)
        {

            if (updateRecord == null) return null;


            var filter = Builders<AirMongoDB>.Filter.Eq("Id", id);
            var update = Builders<AirMongoDB>
                        .Update.Set("amenities", updateRecord.Amenities)
                        .Set("bedrooms", updateRecord.Bedrooms)
                        .Set("listing_url", updateRecord.Listing_url);


            //if (updateRecord.Amenities.Count > 0)
            //{
            //    update.Set("amenisissss", updateRecord.Amenities);
            //}

            //if (updateRecord.Bedrooms > 0)
            //{
            //    update.Set("bedrooms", updateRecord.Bedrooms);
            //}

            await air.UpdateOneAsync(filter, update);

            var recoverAir = await air.Find(filter).FirstOrDefaultAsync();
            return recoverAir;
        }

        public async Task<AirMongoDB> AddAmenities(string id , List<string> Amenities)
        {

            var filter = Builders<AirMongoDB>.Filter.Eq("Id", id);

            var update = Builders<AirMongoDB>.Update
                            .PushEach("amenities", Amenities);


            if (Amenities.Count < 0)
            {
                update.PushEach("amenities", Amenities);
            }

            await air.UpdateOneAsync(filter, update);

            var recoverAir = await air.Find(filter).FirstOrDefaultAsync();
            return recoverAir;


        }

        public void RemoveAir(string id)
        {
            var filter = Builders<AirMongoDB>.Filter.Eq("Id", id);


            air.DeleteOne(filter);

        }
    }
}
