using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saxon.Application.Repository.Repositories.Contract
{
    public interface ICartRepository
    {
        public void  AddToCartRepository(CartDto cartDto,string emailid);
        public void DeleteCartRepository(string EmailID);
        public void DeleteCartById(string CartID);
        public void UpdateCartRepository(CartDto cartDto);
        public IEnumerable GetCartDetailsRepository(string EmailID);
    }
}
