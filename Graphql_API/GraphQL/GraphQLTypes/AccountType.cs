using GraphQL.Types;
using Graphql_API.Entities;

namespace Graphql_API.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of account");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Descripption of account");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId of account");
            Field(x => x.Type, type: typeof(AccountTypeEnumType)).Description("Type of account");
        }
    }
}
