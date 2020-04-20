using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Domain
{
    public class ProductInStock
    {
        public int ProductInStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}