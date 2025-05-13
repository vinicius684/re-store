using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReStore.API.Data;
using ReStore.API.Entities;
using ReStore.API.Extensions;
using ReStore.API.RequestHelpers;

namespace ReStore.API.Controllers
{
    public class ProductsController(StoreContext context) : BaseApiController //use of primary constructor
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]ProductParams productParams)
        {
            var query = context.Products
                .Sort(productParams.OrderBy)
                .Search(productParams.SearchTerm)
                .Filter(productParams.Brands, productParams.Types)
                .AsQueryable();

            return await query.ToListAsync();
        }

        [HttpGet("{id}")] // api/products/2
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return product;
        }
    }
}
