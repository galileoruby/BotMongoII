using BotMongoII.Models.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public interface IZipRepository
    {

        Task<List<ZipMongoModel>> All();


        Task<Boolean> RemoveZipCode(string id);

        Task<Boolean> AddZip(ZipMongoModel zipMongo);
        
    }
}
