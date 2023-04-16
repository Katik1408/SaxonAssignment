using Saxon.Application.Data;
using Saxon.Application.Repository.Repositories.Contract;
using Saxon.Application.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saxon.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        IOrderRepository OrderRepository;
        public OrderService(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }
        public void PlaceOrderService(OrderDto orderDto, string emailid)
        {
            this.OrderRepository.PlaceOrderRepository(orderDto, emailid);
        }
    }
}
