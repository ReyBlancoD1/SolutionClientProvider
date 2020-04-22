using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Order.Common.Enums;

namespace Order.Service.EventHandlers.Commands
{
    public class OrderUpdateCommand : INotification
    {
        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderUpdateDetail> Items { get; set; } = new List<OrderUpdateDetail>();
    }
    public class OrderUpdateDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
