using BotMongoII.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL
{
    public class AmenitiesInputObject : InputObjectGraphType<AirMongoModel>
    {
        public AmenitiesInputObject()
        {
            Name = "AmenitiesInput";

            Description = "List of new amenitites to adding";

            Field(
                    name: "amenities",
                    description: " List of amenitites",
                    type: typeof(ListGraphType<StringGraphType>),
                    resolve:
                        cc => cc.Source.Amenities
            );

        }
    }
}
