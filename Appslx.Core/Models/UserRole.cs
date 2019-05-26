using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appslx.Common;

namespace Appslx.Core.Models
{
    [Table("UserRole")]
    public class UserRole:Entity<int>
    {
        [Key, Required]
        public override int Id { get; set; }

        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required, ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
