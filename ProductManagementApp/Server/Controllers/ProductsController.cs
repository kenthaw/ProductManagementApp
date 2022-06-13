using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductManagementApp.Shared;

namespace ProductManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductsController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Product.ToListAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task <Product>Post([FromBody] Product product)
        {
            EntityEntry<Product> productToAdd = await context.Product.AddAsync(product);
            await context.SaveChangesAsync();
            return productToAdd.Entity;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task <Product>Put(int id, [FromBody] Product product)
        {
            var productToEdit = await context.Product.FindAsync(id);

            if(productToEdit != null)
            {
                productToEdit.ProductName = product.ProductName;
                productToEdit.ProductModel = product.ProductModel;
                productToEdit.PartNumber = product.PartNumber;
                productToEdit.Price = product.Price;
                productToEdit.Quantity = product.Quantity;
                await context.SaveChangesAsync();
            }
            return productToEdit;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<Product> Delete(int id)
        {
            var product = await context.Product.FindAsync(id);
            if (product != null)
            {
                context.Product.Remove(product);
                await context.SaveChangesAsync();
            }
            return product;
        }
    }
}
