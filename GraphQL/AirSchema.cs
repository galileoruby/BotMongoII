using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII.GraphQL
{
    public class AirSchema : Schema
    {
        public AirSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
