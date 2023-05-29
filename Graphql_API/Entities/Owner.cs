using System.ComponentModel.DataAnnotations;

namespace Graphql_API.Entities
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Owner name is mandatory")]
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
