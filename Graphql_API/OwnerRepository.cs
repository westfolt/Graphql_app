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

        public IEnumerable<Owner> GetAll() => _db.Owners.ToList();
    }
}
