using Graphql_API.Contracts;
using Graphql_API.Entities;
using Graphql_API.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Graphql_API
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _db;

        public AccountRepository(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _db.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(a => a.OwnerId);
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId)
        {
            return _db.Accounts.Where(a => a.OwnerId == ownerId);
        }
    }
}
