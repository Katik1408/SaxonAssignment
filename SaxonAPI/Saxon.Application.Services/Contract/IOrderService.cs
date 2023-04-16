using Saxon.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Services.Contract
{
    public interface IOrderService
    {
        public void PlaceOrderService(OrderDto orderDto, string emailid);
    }
}
