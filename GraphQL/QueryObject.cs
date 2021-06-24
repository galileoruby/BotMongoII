using BotMongoII.Database;
using BotMongoII.GraphQL.Types;
using BotMongoII.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

namespace BotMongoII.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IAirRepository repo)
        {
            Name = "Queries";
            Description = " the root query is here, is coming ";

            FieldAsync<ListGraphType<AirObject>, List<AirMongoDB>>(
                 name: "getAll",
                 description: "gest a father description",
                 arguments: null,
                 resolve: cc => repo.All()
            );

            FieldAsync<AirObject,AirMongoDB>(
                 name:"getById",
                 description:"Retrieves one record per id",
                 arguments: new QueryArguments(
                                    new QueryArgument<StringGraphType>
                                    {
                                        Name="id",
                                        Description= "Identificador per record, should be unique"

                                    }),
                 resolve: cc =>
                 {
                     var idCurrent = cc.GetArgument("id",string.Empty);

                     return repo.GetAirMongoById(idCurrent);
                 }
                );

            //FieldAsync<ListGraphType<ZipObject>, List<ZipMongoDB>>(
            //   name: "allZip",
            //   description: "Get all the zip mongo documents",
            //   arguments: null,
            //   resolve: c => repoZip.All()
            //  );

        }
    }
}
