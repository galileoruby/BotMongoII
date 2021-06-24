using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public class ZipLoc
    {
        [BsonElement("y")]

        [BsonRepresentation(BsonType.Decimal128)]

        public decimal Y { get; set; }

        [BsonElement("x")]
        [BsonRepresentation(BsonType.Decimal128)]

        public decimal X { get; set; }
    }
}
