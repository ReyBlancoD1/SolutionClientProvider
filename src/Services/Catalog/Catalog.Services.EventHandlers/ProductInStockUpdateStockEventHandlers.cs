using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Catalog.Services.EventHandlers
{
    public class ProductInStockUpdateStockEventHandlers :
        INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandlers> _logger;

        public ProductInStockUpdateStockEventHandlers(
            ApplicationDbContext context,
            ILogger<ProductInStockUpdateStockEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" --- ProductInStockUpdateStockCommand started");
            
            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation(" --- Retrieve products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock )
                    {
                        _logger.LogError($"Product {entry.ProductId} - doesn´t have enough stock");
                        throw new Exception($"Product {entry.ProductId} - doesn´t have enough stock");
                    }

                    _logger.LogInformation($"Product {entry.ProductId} - its stock was substracted / New stock: { entry.Stock}");
                    entry.Stock -= item.Stock;
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"New stock record was created for {entry.ProductId}");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"Product {entry.ProductId} - its stock was increased / New stock: { entry.Stock}");
                }

            }

            await _context.SaveChangesAsync();
            
            _logger.LogInformation(" --- ProductInStockUpdateStockCommand finished");
        }
    }
}
