using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.Azure.ServiceBus;
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
    public class OrderUpdateEventHandler :
        INotificationHandler<OrderUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderUpdateEventHandler> _logger;
        private readonly ICatalogProxy _catalogProxy;

        public OrderUpdateEventHandler(
            ApplicationDbContext context,
            ICatalogProxy catalogProxy,
            ILogger<OrderUpdateEventHandler> logger)
        {
            _context = context;
            _catalogProxy = catalogProxy;
            _logger = logger;
        }

        public async Task Handle(OrderUpdateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- Order Status update started");
            //var entry = new Domain.Order();
            var stocks = _context.Orders.FirstOrDefault(item => item.OrderId == notification.OrderId);
            
            if (notification.Status == Common.Enums.OrderStatus.Approved)
            {
                if (stocks != null)
                {
                    // Approved information
                    stocks.Status = Common.Enums.OrderStatus.Approved;
                    stocks.CreatedAt = DateTime.UtcNow;

                    _context.Orders.Update(stocks);
                    await _context.SaveChangesAsync();

                    SendNotification(stocks, notification);

                }
            }
            else
            {
                // Cancel information
                stocks.Status = Common.Enums.OrderStatus.Canceled;
                stocks.CreatedAt = DateTime.UtcNow;
                _context.Orders.Update(stocks);
                await _context.SaveChangesAsync();
                using (var trx = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _catalogProxy.UpdateStockAsync(new Proxies.Catalog.Commands.ProductInStockUpdateStockCommand
                        {
                            Items = notification.Items.Select(x => new Proxies.Catalog.Commands.ProductInStockUpdateItem
                            {
                                Action = Proxies.Catalog.Commands.ProductInStockAction.Add,
                                ProductId = x.ProductId,
                                Stock = x.Quantity
                            })
                        });
                    }
                    catch
                    {
                        throw new Exception();
                    }
                    
                    // Update Stock command execute
                    await trx.CommitAsync();

                    SendNotification(stocks, notification);
                }

            }

        }

        private void SendNotification(Domain.Order stocks, OrderUpdateCommand notification)
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
            
            mailMessage.Body = $"Your order {stocks.OrderId} has been {stocks.Status}. {sb}";
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
