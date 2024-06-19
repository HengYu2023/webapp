using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]   //route用controller名稱
    [Route("PRD")]             //直接指定api名稱
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddPRD(string prdName, bool discontinued)
        {
            Product? prd;
            using (var context = new NorthwindContext())
            {
                prd = new Product { ProductName = prdName, Discontinued = discontinued };
                //context.Products.Add(prd);
                context.Products.Add(prd);
                context.SaveChanges();
            }

            return Ok(prd);
        }

        [HttpGet]
        public IActionResult GetPRD(int prdId)
        {
            Product? prd;
            using (var context = new NorthwindContext())
            {
                prd = context.Products.Find(prdId);
            }

            if (prd == null)
            {
                return BadRequest("Invalid ID.");
            }

            return Ok(prd);
        }

        [HttpPut]
        public IActionResult PutPRD(int prdId, string prdName)
        {
            Product? prd;
            using (var context = new NorthwindContext())
            {
                var contextPrd = context.Products;
                prd = contextPrd.Find(prdId);

                if (prd == null)
                {
                    prd = new Product { ProductName = prdName, Discontinued = true };
                    contextPrd.Add(prd);
                }
                else
                {
                    prd.ProductName = prdName;
                    contextPrd.Update(prd);
                }

                context.SaveChanges();
            }

            return Ok(prd);
        }

        [HttpDelete]
        public IActionResult DeletePRD(int prdId)
        {
            Product? prd;
            using (var context = new NorthwindContext())
            {
                prd = context.Categories.Find(ctgId);
                if (prd == null)
                {
                    return BadRequest("Invalid ctgId.");
                }
                context.Remove(prd);
                context.SaveChanges();
            }
            return Ok($"Remove {ctgId} Category.");
        }
    }
}