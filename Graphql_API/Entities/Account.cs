using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graphql_API.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Account type is mandatory")]
        public TypeOfAccount Type { get; set; }
        public string Description { get; set; }

        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }    
}
