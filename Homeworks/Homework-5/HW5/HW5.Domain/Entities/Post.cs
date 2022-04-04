using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW5.Domain.Entities
{
    public class Post
    {
        // Fixed Entity Framework (DbUpdateException) Error: Cannot insert explicit value for identity column in table.
        // Solution: Setting the Identity Column Manually.
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DbId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}