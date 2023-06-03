using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.GraphQL.GraphQLTypes;
using System;


namespace Graphql_API.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery()
        {
            Field("owners", typeof(ListGraphType<OwnerType>))
                .Resolve(context => context.RequestServices?.GetRequiredService<IOwnerRepository>().GetAll());
        }
    }
}
