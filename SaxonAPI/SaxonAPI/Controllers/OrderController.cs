using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using Saxon.Application.Services.Contract;

namespace SaxonAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class OrderController : Controller
    {
        IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDto"></param>
        /// <param name="emailid"></param>
        /// <returns></returns>
        [HttpPost,Route("placeorder")]
        public IActionResult PlaceOrder([FromBody] OrderDto orderDto, string emailid)
        {
            this.orderService.PlaceOrderService(orderDto, emailid);
            return Ok(orderDto);
        }
    }
}
