using AutoMapper;
using Saxon.Application.Data;
using Saxon.Application.Repository.Context;
using Saxon.Application.Repository.Models;
using Saxon.Application.Repository.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saxon.Application.Repository.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        IMapper mapper;
        saxondbContext saxondbContext;

        public OrderRepository(IMapper mapper, saxondbContext saxondbContext)
        {
            this.mapper = mapper;
            this.saxondbContext = saxondbContext;
        }

        public void PlaceOrderRepository(OrderDto orderDto, string emailid)
        {
            orderDto.OrderId = Guid.NewGuid();
            orderDto.CustomerId = saxondbContext.Customer.Where(w => w.EmailId == emailid).Select(w => w.Id).FirstOrDefault();

            int num = new Random().Next();

            orderDto.OrderNumber = "#SP" + num;
            saxondbContext.OrderDetails.Add(mapper.Map<OrderDetails>(orderDto));
            saxondbContext.SaveChanges();
        }
    }
}
