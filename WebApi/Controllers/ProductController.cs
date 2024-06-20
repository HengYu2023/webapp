using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route用controller名稱
    [Route("PRD")]             //直接指定api名稱
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(int prdId)
        {
            Product? prd;
            using (var context = new NorthwindContext())
            {
                prd = context.Products.Find(prdId);
            }

            if (prd == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }
            return Ok(prd);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            using (var context = new NorthwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }


            using (var context = new NorthwindContext())
            {              
                context.Products.Update(product);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            using (var context = new NorthwindContext())
            {
                if (product == null)
                {
                    return NotFound();
                    //return BadRequest("Invalid ctgId.");
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return Ok($"Remove {product}.");
        }
    }
}