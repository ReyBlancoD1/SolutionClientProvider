using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProviderApp.Models;
using System.IO;

namespace ProviderApp.Controllers
{
    public class StockController : Controller
    {
       
        // GET: Stock
        public async Task<IActionResult> Index()
        {
            Route route = new Route().GetRoute();

            ProductStockDto objStock = new ProductStockDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(route.Address + "/v1/products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    objStock = JsonConvert.DeserializeObject<ProductStockDto>(apiResponse);
                }
            }
            return View(objStock);
        }

        public async Task<IActionResult> UpdateProductStock(int id)
        {
            Route route = new Route().GetRoute();
            ProductDto product = new ProductDto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(route.Address + "/v1/products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<ProductDto>(apiResponse);
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductStock(int id, ProductDto product)
        {
            Route route = new Route().GetRoute();
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(route.Address + "/v1/stocks/"),
                    Method = new HttpMethod("PUT"),

                    Content = new StringContent("{\"items\": [ { \"productId\": " + product.productId + ", \"stock\": " + product.stock.Stock + ", \"action\": 0 } ] }", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return RedirectToAction("Index");
        }

    }
}