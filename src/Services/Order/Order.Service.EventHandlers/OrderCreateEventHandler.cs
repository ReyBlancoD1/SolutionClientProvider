using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Domain;
using Order.Persistence.Database;
using Order.Service.EventHandlers.Commands;
using Order.Service.Proxies.Catalog;
using Order.Service.Proxies.Catalog.Commands;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Order.Service.EventHandlers
{
    public class OrderCreateEventHandler :
        INotificationHandler<OrderCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderCreateEventHandler> _logger;
        private readonly ICatalogProxy _catalogProxy;

        public OrderCreateEventHandler(
            ApplicationDbContext context,
            ICatalogProxy catalogProxy,
            ILogger<OrderCreateEventHandler> logger)
        {
            _context = context;
            _catalogProxy = catalogProxy;
            _logger = logger;
        }

        public async Task Handle(OrderCreateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- New order creation started");
            var entry = new Domain.Order();

            using (var trx = await _context.Database.BeginTransactionAsync())
            {
                // 01. Prepare detail
                _logger.LogInformation("--- Preparing detail");
                PrepareDetail(entry, notification);

                // 02. Prepare header
                _logger.LogInformation("--- Preparing header");
                PrepareHeader(entry, notification);

                // 03. Create order
                _logger.LogInformation("--- Creating order");
                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();
                SendNotification(entry, notification);
                _logger.LogInformation($"--- Order {entry.OrderId} was created");

                // 04. Update Stocks
                _logger.LogInformation("--- Updating stock");

                try
                {
                    await _catalogProxy.UpdateStockAsync(new Proxies.Catalog.Commands.ProductInStockUpdateStockCommand
                    {
                        Items = notification.Items.Select(x => new Proxies.Catalog.Commands.ProductInStockUpdateItem
                        {
                            Action = Proxies.Catalog.Commands.ProductInStockAction.Substract,
                            ProductId = x.ProductId,
                            Stock = x.Quantity
                        })
                    });
                }
                catch
                {
                    _logger.LogError("Order couldn't be created because some of the products don't have enough stock");
                    throw new Exception();
                }

                // Lógica para actualizar el Stock
                await trx.CommitAsync();
            }

            _logger.LogInformation("--- New order creation ended");
        }

        private void PrepareDetail(Domain.Order entry, OrderCreateCommand notification)
        {
            entry.Items = notification.Items.Select(x => new OrderDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.Price,
                Total = x.Price * x.Quantity
            }).ToList();
        }

        private void PrepareHeader(Domain.Order entry, OrderCreateCommand notification)
        {
            // Header information
            entry.Status = Common.Enums.OrderStatus.Pending;
            entry.PaymentType = notification.PaymentType;
            entry.ClientId = notification.ClientId;
            entry.CreatedAt = DateTime.UtcNow;

            // Sum
            entry.Total = entry.Items.Sum(x => x.Total);
        }

        private void SendNotification(Domain.Order stocks, OrderCreateCommand notification)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("globarch.aes@gmail.com");
            mailMessage.To.Add("globarch.aes@gmail.com");
            StringBuilder sb = new StringBuilder();
            sb.Append($"\nItems:");

            foreach (var item in notification.Items)
            {
                sb.Append($"\n ProductId - {item.ProductId}");
                sb.Append($"\t Quantity - {item.Quantity}");
                sb.Append($"\t Price - ${item.Price}");
            }

            mailMessage.Body = $"Your quotation {stocks.OrderId} has been created. \n Status: {stocks.Status}. \n{sb}";
            mailMessage.Subject = "subject";
            mailMessage.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("globarch.aes@gmail.com", "AES123456@");
            client.Port = 587;
            client.EnableSsl = true;

            client.Send(mailMessage);
        }
    }
}
