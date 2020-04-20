using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Services.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
