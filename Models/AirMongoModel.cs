using System.Collections.Generic;

namespace BotMongoII.Models
{
    public class AirMongoModel
    {
        public string Id { get; set; }
        public string Listing_url { get; set; }
        public int Accommodates { get; set; }
        public int Bedrooms { get; set; }
        public int Beds { get; set; }
        public int Number_of_reviews { get; set; }
        public List<string> Amenities { get; set; }

    }
}
