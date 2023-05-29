using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Graphql_API.Entities.Context
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        private Guid[] _ids;

        public AccountContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeOfAccount.Cash,
                    Description = "Cash acc",
                    OwnerId = _ids[0]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeOfAccount.Savings,
                    Description = "Savings acc",
                    OwnerId = _ids[1]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = TypeOfAccount.Expense,
                    Description = "Expense acc",
                    OwnerId = _ids[1]
                });
        }
    }
}
