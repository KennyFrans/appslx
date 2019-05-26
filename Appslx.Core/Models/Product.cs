using Appslx.Common;

namespace Appslx.Core.Models
{
    public class Product: AuditableEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
