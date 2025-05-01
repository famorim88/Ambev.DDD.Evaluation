using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public int CartId { get; set; }
        public int? SaleNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; private set; }
        public decimal Total { get; private set; }
        private void HandleDiscount()
        {
            if(Quantity >4 && Quantity < 10)
                Discount = 0.1m;
            if (Quantity >  10)
                Discount = 0.2m;
        }
        private bool HasDiscount() { return Discount > 0; }
        public void HandleTotal(decimal price)
        {
            HandleDiscount();
            Total = price * Quantity;
            if(HasDiscount())
                Total = Total - (Total/Discount);
        }
    }
}
