using GraphQL;
using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.GraphQL.GraphQLTypes;
using System;


namespace Graphql_API.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field("owners", typeof(ListGraphType<OwnerType>))
                .Resolve(context => repository.GetAll());

            Field("owner", typeof(OwnerType))
                .Argument<NonNullGraphType<IdGraphType>>("ownerId")
                .Resolve(context =>
                {
                    Guid id;
                    if(!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }
                    
                    return repository.GetById(id);
                });
        }
    }
}
