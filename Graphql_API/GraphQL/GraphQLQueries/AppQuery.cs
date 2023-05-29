using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.GraphQL.GraphQLTypes;
using System;

#pragma warning disable CS8604

namespace Graphql_API.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery()
        {
            Field("owner", typeof(ListGraphType<OwnerType>))
                .Resolve(context => context.RequestServices.GetRequiredService<IOwnerRepository>().GetAll());
        }
    }
}
