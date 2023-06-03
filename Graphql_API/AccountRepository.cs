using Graphql_API.Contracts;
using Graphql_API.Entities;
using Graphql_API.Entities.Context;
using System;

namespace Graphql_API
{
    public class AccountRepository :IAccountRepository
    {
        private readonly ApplicationContext _db;

        public AccountRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId)
        {
            return _db.Accounts.Where(a => a.OwnerId == ownerId);
        }
    }
}
