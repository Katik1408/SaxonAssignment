using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saxon.Application.Services.Contract
{
    public interface ICartService
    {
        public void AddToCartService(CartDto cartDto,string emailid);
        public void DeleteCartService(string EmailID);
        public void UpdateCartService(CartDto cartDto);
        public IEnumerable GetCartDetailsService(string EmailID);
    }
}
