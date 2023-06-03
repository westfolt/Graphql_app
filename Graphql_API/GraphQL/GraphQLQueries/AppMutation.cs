using GraphQL;
using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.Entities;
using Graphql_API.GraphQL.GraphQLTypes;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Graphql_API.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field(
                "createOwner",
                type: typeof(OwnerType))
                .Argument<NonNullGraphType<OwnerInputType>>("owner")
                .Resolve(context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                });

            Field(
                "updateOwner",
                type: typeof(OwnerType))
                .Arguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" })
                .Resolve(context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("ownerId");

                    var dbOwner = repository.GetById(ownerId);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db"));
                        return null;
                    }

                    return repository.UpdateOwner(dbOwner, owner);
                });

            Field(
                "deleteOwner",
                type: typeof(StringGraphType))
                .Argument<NonNullGraphType<IdGraphType>>("ownerId")
                .Resolve(context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var owner = repository.GetById(ownerId);
                    if(owner == null)
                    {
                        context.Errors.Add(new ExecutionError("No such owner in db"));
                        return null;
                    }

                    repository.DeleteOwner(owner);
                    return $"The owner with id: {ownerId} has been deleted from db";
                });
        }
    }
}
