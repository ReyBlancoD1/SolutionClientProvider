using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProviderApp.Models
{
    public class Route
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Route GetRoute()
        {
            var myJsonString = File.ReadAllText("apigateway.json");
            Route route = JsonConvert.DeserializeObject<Route>(myJsonString);
            return route;
        }
    }
}
