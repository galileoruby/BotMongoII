using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.Database
{
    public class AirMongoDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("listing_url")]
        public string Listing_url { get; set; }



         




        [BsonElement("accommodates")]
        [BsonIgnoreIfNull]
        public int Accommodates { get; set; }


        [BsonElement("bedrooms")]
        [BsonIgnoreIfNull]
        public int Bedrooms { get; set; }


        [BsonElement("beds")]
        public int Beds { get; set; }


        [BsonElement("number_of_reviews")]
        public int Number_of_reviews { get; set; }



        [BsonElement("amenities")]
        [BsonRepresentation(BsonType.String)]

        public List<string> Amenities { get; set; }



        //[BsonElement("images")]
        //[BsonIgnoreIfNull]
        //public Images Images { get; set; }
    }
}
