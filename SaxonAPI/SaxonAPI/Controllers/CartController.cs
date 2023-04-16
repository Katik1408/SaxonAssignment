using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using Saxon.Application.Services.Contract;

namespace SaxonAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CartController : Controller
    {

        ICartService CartService;

        public CartController(ICartService CartService)
        {
            this.CartService = CartService;
        }

        [HttpPost, Route("addToCart")]
        public IActionResult AddItemToCart([FromBody] CartDto cartdto, string emailid)
        {
            this.CartService.AddToCartService(cartdto,emailid);
            return Ok();
        }

        [HttpGet, Route("getCart")]
        public IActionResult GetCartDetails(string emailid)
        {
            return Ok(this.CartService.GetCartDetailsService(emailid));
        }

        [HttpPut, Route("updateCart")]
        public IActionResult UpdateCart([FromBody] CartDto cartdto)
        {
            this.CartService.UpdateCartService(cartdto);
            return Ok();
        }

        [HttpDelete, Route("deleteCart")]
        public IActionResult DeleteCart(string emailId)
        {
            this.CartService.DeleteCartService(emailId);
            return Ok();
        }
    }
}
