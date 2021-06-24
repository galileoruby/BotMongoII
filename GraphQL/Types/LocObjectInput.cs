using BotMongoII.Models.Zip;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL.Types
{
    public class LocObjectInput : InputObjectGraphType<ZipLocModel>
    {

        public LocObjectInput()
        {
            Name = "LocInput";
            Description = "Location within ZipMongo document";


            Field(m => m.X).Description("Coordenate X");
            Field(m => m.Y).Description("Coordenate Y");
        }
    }
}
