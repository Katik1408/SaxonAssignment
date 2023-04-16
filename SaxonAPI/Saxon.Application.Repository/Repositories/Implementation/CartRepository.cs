using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using Saxon.Application.Repository.Context;
using Saxon.Application.Repository.Models;
using Saxon.Application.Repository.Repositories.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saxon.Application.Repository.Repositories.Implementation
{
    public class CartRepository : ICartRepository
    {
        IMapper _mapper;
        saxondbContext _saxondbContext;
        public CartRepository(IMapper _mapper, saxondbContext _saxondbContext)
        {
            this._mapper = _mapper;
            this._saxondbContext = _saxondbContext;

        }

        public void AddToCartRepository(CartDto cartDto, string emailid)
        {
            cartDto.CartId = Guid.NewGuid();
            cartDto.CustomerId = _saxondbContext.Customer.Where(W => W.EmailId == emailid).Select(s => s.Id).FirstOrDefault();

            _saxondbContext.Cart.Add(_mapper.Map<Cart>(cartDto));
            _saxondbContext.SaveChanges();
        }

        public void DeleteCartById(string CartID)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartRepository(string EmailID)
        {
            var CustomerId = _saxondbContext.Customer.Where(W => W.EmailId == EmailID).Select(s => s.Id).FirstOrDefault();

            var cart = _saxondbContext.Cart.Where(w => w.CustomerId == CustomerId).ToList();
            foreach (var item in cart)
            {
                _saxondbContext.Cart.Remove(item);
            }

            _saxondbContext.SaveChanges();

           
        }

        public IEnumerable GetCartDetailsRepository(string EmailID)
        {
            var r = _saxondbContext.Customer.Where(w => w.EmailId == EmailID).Select(s => s.Id).FirstOrDefault();

            var result = _saxondbContext.Cart.Where(w => w.CustomerId == r).Select(s => new
            {
                PizzaName = s.PizzaName,
                PizzaPrice = s.PizzaPrice,
                Quantity = s.Quantity
            }).ToList();
            return result;
        }

        public void UpdateCartRepository(CartDto cartDto)
        {
            throw new NotImplementedException();
        }
    }
}
