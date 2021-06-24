using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using System.Threading.Tasks;
using GraphQL.Types;
using BotMongoII.Database;
using BotMongoII.Models.Zip;

namespace BotMongoII.GraphQL.Zip
{
    public class ZipMutationObject : ObjectGraphType<object>
    {

        public ZipMutationObject(IZipRepository repo)
        {
            Name = "Mutation";
            Description = "The mutation base to zip mongo document";

            FieldAsync<ZipQueryObject, bool>(
                 name: "deleteZip",
                 description: "Delete zip mongo document per Id",
                 arguments: new QueryArguments(
                                new QueryArgument<IdGraphType>
                                {
                                    Name = "id",
                                    Description = "Id for Zip Mongo"
                                }),
                 resolve: cc =>
                 {
                     var idCurrent=cc.GetArgument("id", string.Empty);
                     return repo.RemoveZipCode(idCurrent);
                 });

            FieldAsync<ZipQueryObject, bool>(
                name: "AddZip",
                description: "Add zip new description",
                arguments: new QueryArguments(
                                new QueryArgument<ZipMongoInputObject>
                                {
                                    Name="newZip",
                                    Description ="Add new zip mongo document"
                                }
                        ),
                resolve: cc=>
                {
                    var newRecord=cc.GetArgument<ZipMongoModel>("newZip");

                    return repo.AddZip(newRecord);
                }

                ); 

        }
    }
}
