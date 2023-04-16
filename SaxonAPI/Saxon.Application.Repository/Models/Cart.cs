using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Saxon.Application.Repository.Models
{
    public partial class Cart
    {
        public Guid CartId { get; set; }
        public Guid? CustomerId { get; set; }
        public string PizzaName { get; set; }
        public int? PizzaPrice { get; set; }
        public int? Quantity { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
