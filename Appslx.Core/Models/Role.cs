using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appslx.Common;

namespace Appslx.Core.Models
{
    [Table("Role")]
    public class Role : AuditableEntity<int>
    {
        [Key, Required]
        public override int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
