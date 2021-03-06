﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appslx.Common;

namespace Appslx.Core.Models
{
    [Table("User")]
    public class User:AuditableEntity<int>
    {
        [Key, Required]
        public override int Id { get; set; }

        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, MaxLength(1024)]
        public string PasswordHash { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(1)]
        public string MiddleInitial { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "User Role")]
        public ICollection<int> SelectedUserRole { get; set; }
    }
}
