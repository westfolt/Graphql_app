using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.Entities;

namespace Graphql_API.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property of the owner object");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of the owner");
            Field(x => x.Address, type: typeof(StringGraphType)).Description("Address of the owner");

            Field(name: "accounts", type: typeof(ListGraphType<AccountType>))
                .Resolve(context =>
                {
                    return repository.GetAllAccountsPerOwner(context.Source.Id).ToList();
                });
        }
    }
}
