using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _ctgRepo = new CategoryRepository();
        [HttpGet]
        public IActionResult Get(int ctgId)
        {
            Category? ctg = _ctgRepo.GetById(ctgId);
            

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
            
            _ctgRepo.Add(category);
            _ctgRepo.SaveChanges();
            
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _ctgRepo.Update(category);
            _ctgRepo.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _ctgRepo.Delete(category);
            _ctgRepo.SaveChanges();

            return Ok();
        }
    }
}
