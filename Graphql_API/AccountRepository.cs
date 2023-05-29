using Graphql_API.Contracts;
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
    }
}
