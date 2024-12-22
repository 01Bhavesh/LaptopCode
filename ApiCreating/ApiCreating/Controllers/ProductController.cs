using ApiCreating.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreating.Controllers
{
    [ApiController]
    [Route("/")]
    public class ProductController : Controller
    {

        private static List<Product> products = new List<Product>() {
            new Product { Id=1,ProductName="Bat",Description="Cricket bat",Price=1200},
            new Product { Id=2,ProductName="Ball",Description="Cricket ball",Price=100}, };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;

        }
        [HttpPost]
        public ActionResult<IEnumerable<Product>> PostProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return products;
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            { return NotFound(); }
            p.ProductName = product.ProductName;
            p.Description = product.Description;
            p.Price = product.Price;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if(p == null)
            { return NotFound(); }
            products.Remove(p);
            return NoContent();
        }

    }
}
