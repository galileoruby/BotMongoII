using BotMongoII.Database;
using BotMongoII.GraphQL.Types;
using BotMongoII.Models.Zip;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL.Zip
{
    public class ZipQueryObject : ObjectGraphType<object>
    {
        public ZipQueryObject(IZipRepository repo, IHttpContextAccessor accesor)
        {
            Name = "QueriZip";
            Description = "The root of query zip mongo is here";


            FieldAsync<ListGraphType<ZipObject>, List<ZipMongoModel>>(
                 name: "getAll",
                 description: "Get all the zip mongo documents",
                 arguments: null,
                 resolve: c =>
                 {
                     var headers = accesor.HttpContext.Request.Headers;
                     return repo.All();
                } );


        }
    }
}
