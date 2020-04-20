﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Catalog.Common.Enums;

namespace Catalog.Services.EventHandlers.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
    {
        public IEnumerable<ProductInStockUpdateItem> Items { get; set; } = new List<ProductInStockUpdateItem>();
    }

    public class ProductInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}
