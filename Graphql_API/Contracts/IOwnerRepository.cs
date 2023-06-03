using Graphql_API.Entities;

namespace Graphql_API.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner? GetById(Guid id);
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
        void DeleteOwner(Owner ownerToDelete);
    }
}
