using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Data
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public string PizzaName { get; set; }
        public int? PizzaPrice { get; set; }
        public int? Quantity { get; set; }
        public string OrderNumber { get; set; }
    }
}
