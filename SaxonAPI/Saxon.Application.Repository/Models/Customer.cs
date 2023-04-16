using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Saxon.Application.Repository.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
