using DataAccess.Entities;
using DataAccess.EFRepository;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _ctgRepo = new EFCategoryRepository();
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
            
            _ctgRepo.Insert(category);
            _ctgRepo.Save();
            
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
            _ctgRepo.Save();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int ctgId)
        {           
            _ctgRepo.Delete(ctgId);
            _ctgRepo.Save();

            return Ok($"Remove {ctgId} category.");
        }
    }
}
