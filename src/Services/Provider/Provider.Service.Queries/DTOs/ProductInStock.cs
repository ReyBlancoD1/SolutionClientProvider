﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Service.Queries
{
    public class ProductInStockDto
    {
        public int ProductInStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}