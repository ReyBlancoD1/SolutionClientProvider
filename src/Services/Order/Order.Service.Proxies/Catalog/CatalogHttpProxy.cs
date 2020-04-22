﻿using Microsoft.Extensions.Options;
using Order.Service.Proxies.Catalog.Commands;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.Service.Proxies.Catalog
{
    public class CatalogHttpProxy : ICatalogProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public CatalogHttpProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls
        )
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task UpdateStockAsync(ProductInStockUpdateStockCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync(_apiUrls.CatalogUrl + "v1/stocks", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
