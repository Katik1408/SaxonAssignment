using Saxon.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Repository.Repositories.Contract
{
    public interface IOrderRepository
    {
        public void PlaceOrderRepository(OrderDto orderDto, string emailid);
    }
}
