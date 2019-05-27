using System.Collections.Generic;
using Appslx.Common;

namespace Appslx.Core.Models
{
    public class Order:AuditableEntity<int>
    {
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
