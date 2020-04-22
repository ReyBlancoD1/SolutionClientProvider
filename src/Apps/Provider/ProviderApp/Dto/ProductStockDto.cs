using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProviderApp.Models
{
    public class ProductStockDto
    {       
        public string hasItems { get; set; }

        public List<ProductDto> items { get; set; }
    }
}
