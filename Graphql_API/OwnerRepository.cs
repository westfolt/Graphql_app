using Graphql_API.Contracts;
using Graphql_API.Entities;
using Graphql_API.Entities.Context;
using System;

namespace Graphql_API
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _db;

        public OwnerRepository(ApplicationContext context)
        {
            _db = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _db.Owners.Add(owner);
            _db.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner ownerToDelete)
        {
            _db.Owners.Remove(ownerToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<Owner> GetAll() => _db.Owners.ToList();

        public Owner? GetById(Guid id) => _db.Owners.FirstOrDefault(o => o.Id.Equals(id));

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;

            _db.SaveChanges();

            return dbOwner;
        }
    }
}
