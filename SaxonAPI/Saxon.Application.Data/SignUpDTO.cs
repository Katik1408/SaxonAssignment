using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Data
{
    public class SignUpDTO
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
    }
}
