using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController :ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int ctgId)
        {
            Category? ctg;
            using(var context = new NorthwindContext())
            {
                ctg = context.Categories.Find(ctgId);
            }

            if (ctg == null)
            {
                return NotFound();
                //return BadRequest("Invalid ID.");
            }
            return Ok(ctg);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            
            using (var context = new NorthwindContext())
            {                
                context.Categories.Add(category);
                context.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            

            using (var context = new NorthwindContext())
            {               
                context.Categories.Update(category);
                context.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {            
            using( var context = new NorthwindContext())
            {
                if (category == null)
                {
                    return NotFound();
                    //return BadRequest("Invalid ctgId.");
                }
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return Ok($"Remove {category}.");
        }
    }
}
