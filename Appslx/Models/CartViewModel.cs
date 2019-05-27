namespace Appslx.Web.Models
{
    public class CartViewModel
    {
        private decimal _tax;
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; } = 0;
        public decimal Price { get; set; }
        public string IsOrderedBy { get; set; }

        public decimal Tax
        {
            get { return this._tax = this.Price * (decimal) 0.10; }
        }
    }
}
