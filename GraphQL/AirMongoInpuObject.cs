using BotMongoII.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL
{
    public class AirMongoInpuObject : InputObjectGraphType<AirMongoModel>
    {
        public AirMongoInpuObject()
        {
            Name = "NewAirInput";
            Description = "Add new air mongo on database";

            Field(r => r.Accommodates).Description("Acomodates ");

            Field(
                    name: "amenities",
                    description: " List of amenitites",
                    type: typeof(ListGraphType<StringGraphType>),
                    resolve:
                        cc => cc.Source.Amenities
            );


            Field(r => r.Bedrooms).Description("bedrooms");
            Field(r => r.Beds).Description("beds");
            Field(r => r.Id, nullable: true).Description("El id autogenerado");
            Field(r => r.Listing_url).Description("listing url");
            Field(r => r.Number_of_reviews).Description("number of review, esto es caludlado");

        }

    }
}
