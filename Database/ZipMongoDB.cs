using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BotMongoII.Database
{
    public class ZipMongoDB
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("zip")]
        public string Zip { get; set; }


        [BsonElement("loc")]
        [BsonIgnoreIfNull]
        //[BsonSerializer(typeof(Loc))]

        public ZipLoc Loc { get; set; }


        [BsonElement("pop")]
        [BsonRepresentation(BsonType.Int32)]

        public int Pop { get; set; }


        [BsonElement("state")]
        [BsonRepresentation(BsonType.String)]

        public string State { get; set; }



    }


     
     



}
