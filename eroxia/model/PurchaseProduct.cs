using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class PurchaseProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return Product.Price * Quantity; }
        }
        public PurchaseProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
