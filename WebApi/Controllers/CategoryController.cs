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
                return BadRequest("Invalid ID.");
            }
            return Ok(ctg);
        }
    }
}
