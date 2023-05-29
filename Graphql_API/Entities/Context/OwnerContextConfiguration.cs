using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Graphql_API.Entities.Context
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {
        private Guid[] _ids;

        public OwnerContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
                .HasData(
                new Owner
                {
                    Id = _ids[0],
                    Name = "Jack Dickins",
                    Address = "Jack's street"
                },
                new Owner
                {
                    Id = _ids[1],
                    Name = "Bob Baggins",
                    Address = "Bob's avenue"
                });
        }
    }
}
