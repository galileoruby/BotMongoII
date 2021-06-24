using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL.Zip
{
    public class ZipSchema : Schema
    {
        public ZipSchema(ZipQueryObject query, ZipMutationObject mutation, IServiceProvider serviceProvider) :
                    base(serviceProvider)
        {

            Query = query;
            Mutation = mutation;

            //directivas
            //Directives.Register()

            //fieldMiddlerware
            //FieldMiddleware.Use(new Instance());
            
             
        }
    }
}
