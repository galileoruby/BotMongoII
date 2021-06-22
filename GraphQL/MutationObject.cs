using BotMongoII.Database;
using BotMongoII.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GraphQL;
using BotMongoII.Models;

namespace BotMongoII.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {

        public MutationObject(IAirRepository repository)
        {
            Name = "Mutations";
            Description = "The base of mutations are here"; ;

            FieldAsync<AirObject, AirMongoDB>(
                 name: "addAir",
                 description: "Adding new air object to mongodb",
                 arguments: new QueryArguments(
                                new QueryArgument<AirMongoInpuObject>
                                {
                                    Name = "AirMongo",
                                    Description = "This is the new records airmongo"
                                }
                    ),
                 resolve: cc =>
                 {
                     var airCurrent = cc.GetArgument<AirMongoModel>("AirMongo");
                     var newRecord = repository.AddNewAir(airCurrent);

                     return newRecord;

                 });


            FieldAsync<AirObject, AirMongoDB>(
                 name: "updateamenities",
                 description: "Update AirBd",
                 arguments: new QueryArguments(
                                new QueryArgument<IdGraphType>
                                {
                                    Name = "idAir",
                                    Description = "IdAir"
                                },
                                new QueryArgument<AirMongoInpuObject>
                                {
                                    Name = "record",
                                    Description = "all properties that"
                                }
                                ),
                 resolve: cc =>
                 {
                     var idCurrent = cc.GetArgument("idAir", string.Empty);
                     var record = cc.GetArgument<AirMongoModel>("record");
                     var req = repository.UpdateAir(idCurrent, record);
                     return req;
                 });

            FieldAsync<AirObject, AirMongoDB>(
                 name: "addAmenities",
                 description: "Add extra items on amenitites record",
                 arguments: new QueryArguments(
                                    new QueryArgument<IdGraphType>
                                    {
                                        Name = "idAir",
                                        Description = "idAir description"
                                    },
                                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>>
                                    {
                                        Name = "newAmenitites",
                                        Description = "new items to amenitites" 
                                    }),

                 resolve: cc =>
                 {

                     var idCurrent = cc.GetArgument("idAir", string.Empty);

                     var record = cc.GetArgument<List<string>>("newAmenitites");

                     return repository.AddAmenities(idCurrent, record);
                 }

                );


            Field<AirObject>(
                name: "deleteAir",
                description: "Delete an air object by id",
                arguments: new QueryArguments(
                                    new QueryArgument<IdGraphType>
                                    {
                                        Name = "idAir",
                                        Description = "Delete one record air mongo by its Id"
                                    }),
                resolve: cc =>
                {
                    var idCurrent = cc.GetArgument("idAir", string.Empty);

                    repository.RemoveAir(idCurrent);
                    return null;

                });

        }
    }
}
