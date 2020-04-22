using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProviderApp.Models
{
    public class Stock
    {       
        public string hasItems { get; set; }

        public List<ProductStock> items { get; set; }
    }
}
