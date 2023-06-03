using Graphql_API.Entities;

namespace Graphql_API.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
    }
}
