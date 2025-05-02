using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReStore.API.Data;
using ReStore.API.DTOs;
using ReStore.API.Entities;
using ReStore.API.Extensions;

namespace ReStore.API.Controllers
{
    public class BasketController(StoreContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetrieveBasket();

            if (basket == null) return NoContent();
            
            return basket.ToDto();
        }

        [HttpPost]
        public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
        {
            var basket = await RetrieveBasket();

            basket ??= CreateBasket();

            var product = await context.Products.FindAsync(productId);

            if(product == null) return BadRequest("Problem adding item to basket");
            
            basket.AddItem(product, quantity);

            var result = await context.SaveChangesAsync() > 0;

            if(result) return CreatedAtAction(nameof(GetBasket), basket.ToDto());//201Created + where to find the returned resource + returned basket

            return BadRequest("Problem updating basket");
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {
            var basket = await RetrieveBasket();


            if(basket ==null) return BadRequest("Unable to retrive basket");

            basket.RemoveItem(productId, quantity);
            
            var result = await context.SaveChangesAsync() > 0;
            
            if(result) return Ok();

            return BadRequest("problem updating basket");
        }

        private Basket CreateBasket()
        {
            var basketId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions
            {
                IsEssential=true,//Even if the user says "I don't want cookies", these can still be used within the app.
                Expires = DateTime.UtcNow.AddDays(30)
            };
            Response.Cookies.Append("basketId",basketId, cookieOptions);
            var basket = new Basket {BasketId = basketId};
            context.Baskets.Add(basket);//We are not doing anything with the bank, we are simply asking EF to track this new basket in memory.
            return basket;

        }

        private async Task<Basket?> RetrieveBasket()
        {
            return await context.Baskets
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.BasketId == Request.Cookies["basketId"]);
        }

    }
}
