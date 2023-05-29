using Graphql_API.Entities;

namespace Graphql_API.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
}
