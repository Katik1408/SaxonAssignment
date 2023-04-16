using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Saxon.Application.Data;
using Saxon.Application.Repository.Repositories.Contract;
using Saxon.Application.Services.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saxon.Application.Services.Implementation
{
    public class CartService : ICartService
    {
        public readonly ICartRepository CartRepository;
        public CartService(ICartRepository CartRepository)
        {
            this.CartRepository = CartRepository;
        }

        public void AddToCartService(CartDto cartDto, string emailid)
        {
             this.CartRepository.AddToCartRepository(cartDto,emailid);
        }

        public void DeleteCartService(string EmailID)
        {
            this.CartRepository.DeleteCartRepository(EmailID);
        }

        public IEnumerable GetCartDetailsService(string EmailID)
        {
            return this.CartRepository.GetCartDetailsRepository(EmailID);
        }

        public void UpdateCartService(CartDto cartDto)
        {
            throw new NotImplementedException();
        }
    }
}
