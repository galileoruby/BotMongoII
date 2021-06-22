using BotMongoII.Database;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL.Types
{
    public class AirObject : ObjectGraphType<AirMongoDB>
    {
        public AirObject()
        {
            Name = nameof(AirMongoDB);
            Description = "An air on the database";

            Field(m => m.Id).Description("id");
            Field(m => m.Listing_url).Description("Listing_url");
            Field(m => m.Accommodates).Description("Accommodates");
            Field(m => m.Bedrooms).Description("bedrooms");
            Field(m => m.Number_of_reviews).Description("number ofreviews");
            Field(m => m.Beds).Description("beds");
            Field(
                name: "amenitites",
                description: "Description of amenititesa",                 
                type: typeof(ListGraphType<StringGraphType>),
                resolve: m => m.Source.Amenities
            );
        }

    }
}
