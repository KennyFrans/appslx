using Appslx.Common;

namespace Appslx.Core.Models
{
    public class OrderDetail:AuditableEntity<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public decimal TotalPrice
        {
            get => this.TotalPrice;
            set => this.TotalPrice = Qty * UnitPrice;
        }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
