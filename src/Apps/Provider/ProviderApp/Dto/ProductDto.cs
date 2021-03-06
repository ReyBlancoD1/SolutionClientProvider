﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProviderApp.Models
{
    public class ProductDto
    {
        public int productId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public StockDto stock { get; set; }
    }
}
