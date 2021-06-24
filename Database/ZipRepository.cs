using AutoMapper;
using BotMongoII.Models.Zip;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public class ZipRepository : IZipRepository
    {

        private readonly IMongoCollection<ZipMongoDB> zip;
        private readonly IMapper _mapper;

        public ZipRepository(IConfiguration config, IMapper mapper)
        {
            MongoClient client = new MongoClient(config.GetSection("Database").GetSection("Conection").Value);
            IMongoDatabase database = client.GetDatabase(config.GetSection("Database").GetSection("Name").Value);

            zip = database.GetCollection<ZipMongoDB>("zipMongo");
            _mapper = mapper;
        }

        public Task<bool> AddZip(ZipMongoModel zipMongo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ZipMongoModel>> All()
        {
            var result = await zip.Find(zip => true).ToListAsync();             
            List<ZipMongoModel> destination = _mapper.Map<List<ZipMongoDB>, List<ZipMongoModel>>(result);

            return destination;
        }

        public Task<bool> RemoveZipCode(string id)
        {
            throw new NotImplementedException();
        }
    }
}
