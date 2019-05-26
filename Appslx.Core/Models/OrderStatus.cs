using System.Collections.Generic;
using Appslx.Common;

namespace Appslx.Core.Models
{
    public class OrderStatus:AuditableEntity<int>
    {
        public string Descrition { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
