using BotMongoII.Database;
using BotMongoII.Models.Zip;
using GraphQL.Types;

namespace BotMongoII.GraphQL.Types
{
    public class ZipObject : ObjectGraphType<ZipMongoModel>
    {

        public ZipObject()
        {

            Name = nameof(ZipMongoDB);
            Description = "An zip on collection database";

            Field(m => m.City).Description("City");
            Field(m => m.Id).Description("Id an object zipcode");
            Field(m => m.Zip).Description("Zip code");             
            Field(
                 name: "loc",
                 description: "list of x, y",
                 type: typeof(LocObject),
                 resolve: m => m.Source.Loc
                );

        }

    }
}
