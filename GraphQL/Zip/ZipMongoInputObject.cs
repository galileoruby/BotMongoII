using BotMongoII.Database;
using BotMongoII.GraphQL.Types;
using BotMongoII.Models.Zip;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL.Zip
{
    public class ZipMongoInputObject: InputObjectGraphType<ZipMongoModel>
    {
        public ZipMongoInputObject()
        {

            Name = "NewZipMongo";
            Description = "Add new zipmongo document on database";

            Field(r => r.City).Description("City of the zip ");
            Field(r => r.Id, nullable:true).Description("City of the zip ");
            Field(r => r.Zip ).Description("Zip code on zipmongo");


            //Field(r => r.Loc).Description("X,Y Coordenates location");

            Field(
                name: "loc",
                description: "list of x, y",
                type: typeof(LocObjectInput),
                resolve: m => m.Source.Loc
               );

        }

    }
}
