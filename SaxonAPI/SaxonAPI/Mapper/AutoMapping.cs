using AutoMapper;
using Saxon.Application.Data;
using Saxon.Application.Repository.Models;

namespace SaxonAPI.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SignUpDTO, Customer>();
            CreateMap<Customer, SignUpDTO>();
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();
            CreateMap<OrderDetails, OrderDto>();
            CreateMap<OrderDto, OrderDetails>();

        }

    }
}
